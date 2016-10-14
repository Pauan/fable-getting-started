Fable Quick Start
=================

It can be difficult to figure out how to properly setup Fable, especially if
you're not familiar with modern front-end JavaScript development.

This repository contains fully working code, so it is easy to get started.

In addition, it also shows how to do the following:

* Import local JavaScript code into F#

* Download libraries with npm and then import them into F#

* Use your project as an application in either a browser or Node.js

* Publish your project as a library on GitHub or npm

Installing the project
======================

After downloading this repository, make sure that you are in the
`fable-getting-started` directory. All of the commands assume that you are at
the root of the project: they will not work if you are in a sub-folder!

Now you must use `npm install` which will download all of the necessary
dependencies.

You do not need to install Fable globally. Instead, Fable will be installed
locally inside of the `node_modules` folder. This makes it easier for other
people to contribute to your project: they do not need to install Fable
globally, and it also guarantees that everybody is compiling your project with
the correct version of Fable.

Customization
=============

You will probably want to change the following files:

* `package.json`

  * `name`

  * `description`

  * `version`

* `rollup.config.js`

  * `moduleName`

Compiling your project
======================

Your project is automatically compiled when running `npm install`. It is also
automatically compiled when publishing to npm.

You can use `npm run build` to manually compile your project at any time.

If you instead use `npm run watch` then it will compile your project, and will
then automatically recompile your project if any of your `.fsx` or `.js` files
change.

Not only is this much more convenient, but it's faster too, because it only
recompiles the files that actually changed, rather than compiling your entire
project from scratch.

Running your project
====================

After compiling, the final JavaScript code will be in the `dist/umd/main.js`
file. You can run that file directly in either a browser or Node.js.

If you want to run it in Node.js, you can use `node .` or
`node dist/umd/main.js` (they both do the same thing).

Making changes to the project
=============================

You can modify the `.fsx` files in the `fsx` folder, and you can modify the
`.js` files in the `js` folder.

The `.fsx` files are F# code, which will be compiled by Fable.

The `.js` files are JavaScript code, which will be compiled by Babel and will
be bundled into your compiled code.

How to import JavaScript code into F#
=====================================

First, make sure that you have the following line in your `main.fsx` file:

```
#r "../node_modules/fable-core/Fable.Core.dll"
```

Don't worry: this repository already includes the above line in `main.fsx`.

Now you can import `.js` files into `.fsx` by using the following attribute:

```
[<Fable.Core.Import("foo", "../js/foo.js")>]
```

If you are using a lot of imports you can do this:

```
open Fable.Core
```

Now you no longer need the `Fable.Core` prefix when importing:

```
[<Import("foo", "../js/foo.js")>]
```

You can see an example in the `fsx/message.fsx` file.

This works for any local JavaScript files in the `js` folder, but it also
works for builtin Node.js modules or JavaScript files which have been
downloaded with npm:

```
[<Import("join", "path")>]
```

```
[<Import("foo", "other-package/foo.js")>]
```

If the file path starts with `.` or `..` then it is local to your project.

If the file path does not start with `.` or `..` then it is an npm package.
That means that it is either a builtin Node.js module (e.g. `path`, `fs`,
etc.) or it is a package in the `node_modules` folder.

How to download npm dependencies
================================

If there is an npm package called `foo` that you want to use in your project,
then you can do either of the following:

* Use `npm install --save-dev foo`

* Manually edit the `package.json` file and add `foo` to the `devDependencies`

  In certain situations you may need to add the package to `dependencies`
  rather than `devDependencies`

Generally the first option is better, but the second option gives you more
precise control.

After doing one of the above steps, use `npm install` to download the
`foo` package.

How to upgrade npm dependencies
===============================

You can use `npm outdated` which will tell you which of your dependencies are
out of date.

You can then do either of the following:

* Manually edit `package.json` to use the most up-to-date versions.

* Use `npm install --save-dev foo` which will edit `package.json` to use the
  latest version for the package `foo`

Now you can use `npm install` to download the new versions.

Locking down the npm dependencies
=================================

If you are distributing an application, it can be useful to use
`npm shrinkwrap --dev`. This creates an `npm-shrinkwrap.json` file which lists
the exact version of every dependency that your project uses.

When you use `npm install`, if there is an `npm-shrinkwrap.json` file, then it
will use the exact versions specified in `npm-shrinkwrap.json`

You can check the `npm-shrinkwrap.json` file into git, which guarantees that
anybody who compiles your application will use the exact same versions that
you do, which helps to prevent bugs. It is recommended to only do this for
applications, not for libraries.

If you want to upgrade your dependencies:

1. Make a backup of the `npm-shrinkwrap.json` file

2. Delete the `npm-shrinkwrap.json` file

3. Upgrade your dependencies

4. Use `npm shrinkwrap --dev` which will write out the new
   `npm-shrinkwrap.json` file.

5. Check the new `npm-shrinkwrap.json` file into git

If the upgrade failed (for any reason), you can restore the backup
`npm-shrinkwrap.json` file, which will cause it to revert back to the previous
versions.

By following these steps, your project will always use versions which are
guaranteed to work.

Distributing your project as a library
======================================

You can push your project to a hosting site such as GitHub, or you can
[publish it to npm](https://docs.npmjs.com/misc/developers).

If somebody else uses your project as a library, everything should work
seamlessly.

If it doesn't work, then they can do one of the following:

* If they are using CommonJS/RequireJS/globals they can import `dist/umd/main.js`

* If they are using ES2015 modules, they can import `dist/es2015/main.js`
