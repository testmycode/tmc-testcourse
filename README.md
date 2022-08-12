This is an example of what **exercise repositories** in [secret-project](https://github.com/rage/secret-project-331) look like.

## Part directories
Exercises are grouped into directories, or `parts`. These may or may not correspond to specific sections of your course.

The part directories should be at the project root. They do not have any required naming scheme.

## Exercise directories
Exercises should be in their own directories directly under a part directory.

The names of each exercise directory should be unique, so instead of `part01/exercise` and `part02/exercise`, it's better to have `part01/exercise` and `part02/another_exercise`. Repeated names are not disallowed but may cause issues during updates.

## Updating exercises
secret-project can automatically detect when an exercise is modified as long as one of the following is not changed:

- The exercise directory name
- The contents of the exercise

## Other
Exercise repositories should be private to avoid the solutions being publicly viewable. secret-project can access private repositories using a read-only deploy key.
