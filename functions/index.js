const functions = require('firebase-functions')
const storage = require('@google-cloud/storage')()
const admin = require('firebase-admin')

admin.initializeApp(functions.config().firebase)

exports.version = functions.https.onRequest((request, response) => {
  admin.firestore().collection('changes').orderBy('version', 'desc').limit(1).get().then((querySnapshot) => {
    querySnapshot.forEach(doc => {
      doc = doc.data()
      response.json(Object.assign({}, doc, {number: doc.version, href: doc.link_website}))
    })
  }).catch((error) => console.error(error))
})

exports.download = functions.https.onRequest((request, response) => {
  admin.firestore().collection('changes').orderBy('version', 'desc').limit(1).get().then((querySnapshot) => {
    response.set('Access-Control-Allow-Origin', '*')
    querySnapshot.forEach(doc => {
      doc = doc.data()
      response.json({'version': doc.version, 'link_download': doc.link_download})
    })
  }).catch((error) => console.error(error))
})

exports.changes = functions.https.onRequest((request, response) => {
  admin.firestore().collection('changes').orderBy('version', 'desc').get().then((querySnapshot) => {
    let changes = []
    response.set('Access-Control-Allow-Origin', '*')
    querySnapshot.forEach(doc => {
      changes.push(doc.data())
    })
    response.json(changes)
  }).catch((error) => console.error(error))
})

exports.onNewVersionFileAdded = functions.storage.object().onChange(event => {
  const object = event.data
  //only if version.json file is created
  if (!object.name.includes('version.json') || object.resourceState !== 'exists') return Promise.resolve()
  console.info('Detected new version.json file!', object)

  return storage.bucket(object.bucket).file(object.name)
    .download()
    .then(version => {
      if (version) {
        return version.toString('utf-8')
      }
    })
    .then(version => {
      if (version) {
        console.info('version.json downloaded from bucket, creating document...', version)
        return admin.firestore().collection('changes')
          .add(Object.assign({}, JSON.parse(version), {date: new Date()}))
      }
    })
    .then(docRef => {
      if (docRef && docRef.id) {
        console.info(`Document created -> ${docRef.id}`)
      }
    })
    .catch(error => console.error(error))
})
