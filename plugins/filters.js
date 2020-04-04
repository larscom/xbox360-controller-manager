import Vue from 'vue';

Vue.filter('date', timestamp => (timestamp ? new Date(timestamp._seconds * 1000).toDateString() : null));
