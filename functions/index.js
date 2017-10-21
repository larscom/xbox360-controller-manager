const functions = require('firebase-functions');
const storage = require("@google-cloud/storage")();
const admin = require('firebase-admin');

admin.initializeApp(functions.config().firebase);

exports.version = functions.https.onRequest((request, response) => {
  admin.firestore().collection('changes').orderBy('version', 'desc').limit(1).get().then((querySnapshot) => {
    querySnapshot.forEach((doc) => {
      let docData = doc.data();
      response.json(Object.assign({}, docData, { number: docData.version, href: docData.link_website }));
    });
  }).catch((error) => console.error(error));
});

exports.download = functions.https.onRequest((request, response) => {
  admin.firestore().collection('changes').orderBy('version', 'desc').limit(1).get().then((querySnapshot) => {
    response.set('Access-Control-Allow-Origin', '*');
    querySnapshot.forEach((doc) => {
      response.json(doc.data());
    });
  }).catch((error) => console.error(error));
});

exports.onNewVersionFileAdded = functions.storage.object().onChange(event => {
  const object = event.data;
  //only if version.json file is created
  if (!object.name.includes('version.json') || object.resourceState !== 'exists' || object.metageneration !== '1') return Promise.resolve();
  console.info('Detected new version.json file!', object);

  return storage.bucket(object.bucket).file(object.name)
    .download()
    .then(version => {
      if (version) {
        return version.toString('utf-8');
      }
    })
    .then(version => {
      if (version) {
        console.info('version.json downloaded from bucket, creating document...', version);
        return admin.firestore().collection('changes')
          .add(Object.assign({}, JSON.parse(version), { date: new Date() }));
      }
    })
    .then(docRef => {
      if (docRef && docRef.id) {
        console.info(`Document created -> ${docRef.id}`);
      }
    })
    .catch(error => console.error(error));
});
