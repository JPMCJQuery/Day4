QUnit.test("assert.ok() Test", function(assert) {
	assert.ok(1 == "1", 	"1 equals '1'");
//	assert.ok(1 === "1", 	"1 equals and same type as '1'");
});

// More info in failed results
QUnit.test("assert.equal() Test", function(assert) {
    	assert.equal(1, 1, 	"1 equals 1");
// 	assert.equal(1, 2, 	"1 equals 2");
	assert.equal(1, "1", 	"1 equals '1'");
//	assert.deepEqual(1, "1","1 deepEquals '1'");
})

// Note, not QUnit or assert in front and it works
test("isEven() Test", function() {
    	ok(isEven(0), 		"Zero is an even number");
    	ok(isEven(2), 		"So is two");
    	ok(isEven(-4), 		"So is negative four");
    	ok(!isEven(1), 		"One is not an even number");
    	ok(!isEven(-7), 	"Neither is negative seven");
});

QUnit.test("jQuery Loaded Test", function () {
	ok($,			"jQuery is Loaded");
});



