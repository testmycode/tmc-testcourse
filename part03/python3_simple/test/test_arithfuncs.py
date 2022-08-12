import unittest, sys

from tmc import points

from tmc.utils import load, get_out

sum = load('src.arithfuncs', 'sum')

@points('python3_1')
class TestCase(unittest.TestCase):

    @points('py3')
    def test_new(self):
        self.assertEqual(sum(1, 2), 3);

if __name__ == '__main__':
    unittest.main()
