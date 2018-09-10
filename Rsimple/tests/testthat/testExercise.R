library("testthat")

points_for_all_tests(c("r1"))

test("a value as expected", c("r1.1"), {
  expect_equal(a, 0.84147, tolerance = 1e-3)
})

test("add works as expected", c("r1.2"), {
  expect_equal(add(1, 1), 2)
  expect_equal(add(0, 1), 1)
  expect_equal(add(0, 0), 0)
  expect_equal(add(5, 5), 10)
  expect_equal(add(0, -2), -2)
})

test("mul works as expected", c("r1.3"), {
  expect_equal(mul(0,0), 0)
  expect_equal(mul(-1,10), -10)
  expect_equal(mul(2,2), 4)
  expect_equal(mul(-3,-4), 12)
})
