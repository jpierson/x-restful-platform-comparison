var fetch = require('node-fetch')

function checkStatus(response) {
  if (response.status >= 200 && response.status < 300) {
    return response
  } else {
    var error = new Error(response.statusText)
    error.response = response
    throw error
  }
}

module.exports.getFeedbackById = (id) => {
    return fetch(`http://localhost:4052/api/feedback/${encodeURIComponent(id)}`)
        .then(checkStatus)
        .then(response => response.json())
}

module.exports.getAllFeedback = (id) => {
    return fetch('http://localhost:4052/api/feedback')
        .then(checkStatus)
        .then(response => response.json())
}