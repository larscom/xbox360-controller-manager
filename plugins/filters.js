import Vue from 'vue'

Vue.filter('date', (date) => date ? new Date(date).toDateString() : null);
