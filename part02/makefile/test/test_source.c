#include <check.h>
#include "tmc-check.h"
#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <time.h>
#include <math.h>
#include "../src/source.h"


START_TEST(test_sum)
{
    fail_unless(my_sum_function(1, 2) == 3, "My own sum function should sum 1 and 2 resulting in 3");
}
END_TEST

int main(int argc, const char *argv[])
{
    srand((unsigned)time(NULL));
	Suite *s = suite_create("Test-demo");
	tmc_register_test(s, test_sum, "1");
	return tmc_run_tests(argc, argv, s);
}
