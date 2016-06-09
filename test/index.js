var mocha = require('mocha');
var expect = require('chai').expect;
var fetch = require('node-fetch');
var apiClient = require('./api-client');

describe("Feedback API", () => {
    it("gets all feedback", (done) => {
        apiClient
            .getAllFeedback()
            .then(feedback => {
                expect(feedback).is.an("array")
                done();
            })
            .catch(done);
    });
});