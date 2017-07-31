describe("A suite", function () {
    it("contains spec with an expectation", function () {
        expect(true).toBe(true);
    });
});

describe("Test GET REST", function () {
    var resultado;
    it("Peticion prueba GET REST", function (done) {
        $.get("api/values/3", function (data) {
            resultado = data;
            done();
        });
    });
    afterEach(function(done){
        expect(resultado).toBe("value");
        done();
    },1000);
});