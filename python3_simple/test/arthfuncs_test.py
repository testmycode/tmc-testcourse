import unittest, sys

from tmc import points

from tmc.utils import load, get_out

Arithfuncs = load('src.arithfuncs', 'Arithfuncs')

@points('python3_1')
class TestCase(unittest.TestCase):

    @points('py3')
    def test_new(self):
        self.assertEqual(Arithfuncs.sum(1,2), 3);

if __name__ == '__main__':
    unittest.main()
