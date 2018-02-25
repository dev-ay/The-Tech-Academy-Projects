var request = require("request")

describe('calc', () => {
    it("should multiply 2 and 2", () => {
        expect(2*2).toBe(4)
    })
});

describe("get messages", () => {
    it("should return 200 OK", (done) => {
        request.get("http://localhost:3000/messages", (error, response) => {
            expect(response.statusCode).toEqual(200)
            done()
        })
    })
    it("should return a list that's not empty", (done) => {
        request.get("http://localhost:3000/messages", (error, response) => {
            expect(JSON.parse(response.body).length).toBeGreaterThan(0)
            done()
        })
    })
})