Fable Quick Start
=================

It can be difficult to figure out how to properly setup Fable.

This repository contains fully working code, so it is easy to get started.

In addition, it also shows how to do the following:

* Import local JavaScript code into F#

* Download JavaScript libraries and then import them into F#

* Use your project as an application in either a browser or Node.js

* Distribute your project as a library which can be used in other projects

Downloading the project
=======================

Make sure you have Git installed, and then run the following command in a
terminal:

```
git clone https://github.com/Pauan/fable-getting-started.git
```

That command will download this repository and place it into the
`fable-getting-started` folder.

Installing the project
======================

Make sure that you are in the `fable-getting-started` folder. All of the
following commands assume that you are at the root of the project: they will
not work if you are in a sub-folder!

Make sure that you have [`node`](https://nodejs.org/en/) and
[`yarn`](https://yarnpkg.com/) installed.

You can get [`yarn`](https://yarnpkg.com/) from either
[its website](https://yarnpkg.com/en/docs/install) or by using the following
command:

```
npm install --global yarn
```

Now you must use the [`yarn install`](https://yarnpkg.com/en/docs/cli/install)
command, which will download all of the necessary dependencies. After the
dependencies are downloaded, it will then automatically compile your project.

You can instead use [`yarn`](https://yarnpkg.com/en/docs/cli/install) which is
exactly the same as [`yarn install`](https://yarnpkg.com/en/docs/cli/install)

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

You can use whatever name you want for your project, as long as nobody else
has taken the name first.

Compiling your project
======================

Your project is automatically compiled when running
[`yarn`](https://yarnpkg.com/en/docs/cli/install). It is also automatically
compiled when publishing to npm.

Alternatively, you can use [`yarn run build`](https://yarnpkg.com/en/docs/cli/run)
to manually compile your project. It is the same as using
[`yarn`](https://yarnpkg.com/en/docs/cli/install), except that it does not
download any libraries, so you must run
[`yarn`](https://yarnpkg.com/en/docs/cli/install) first before you can use
[`yarn run build`](https://yarnpkg.com/en/docs/cli/run)

If you use [`yarn run watch`](https://yarnpkg.com/en/docs/cli/run) then it
will compile your project (exactly the same as
[`yarn run build`](https://yarnpkg.com/en/docs/cli/run)), but it will also
automatically recompile your project if you make any changes to the `.fs` or
`.js` files.

If you want to stop watch mode, just hit the `Enter` key.

Watch mode is very convenient, and it's also **much** faster, because it only
recompiles the files that actually changed, rather than compiling your
entire project from scratch.

After making a minor change to a single `.fs` file,
[`yarn run build`](https://yarnpkg.com/en/docs/cli/run) takes 4,000
milliseconds, but [`yarn run watch`](https://yarnpkg.com/en/docs/cli/run)
takes only 40 milliseconds! The times may be slower or faster depending on
your computer, but watch mode is always faster than a full build.

Running your project
====================

After compiling, the final JavaScript code will be in the `dist/umd/Main.js`
file.

If you want to run it in a browser, you can include it in an HTML `<script>`
tag:

```
<script src="dist/umd/Main.js"></script>
```

If you want to run it in Node.js, you can use `node .` or
`node dist/umd/Main.js` (they both do the same thing)

Making changes to the project
=============================

You can modify the `.fs` files in the `fs` folder, and you can modify the
`.js` files in the `js` folder.

The `.fs` files are F# code, which will be compiled by Fable.

The `.js` files are JavaScript code, which will be compiled by Babel and will
be bundled into your compiled code.

If you want to add more `.fs` files, you will need to edit the
`fs/Main.fsproj` file. As an example, if you want to add in a new `Foo.fs`
file, you will need to add the following code to `fs/Main.fsproj`:

```
<Compile Include="Foo.fs" />
```

This should be placed in the same `ItemGroup` as the other `.fs` files. Also,
the order matters! If a file `Foo.fs` uses a file `Bar.fs`, then `Bar.fs` must
be on top of `Foo.fs`

That also means that `Main.fs` must be at the bottom, because it depends on
everything else and nothing depends on it.

How to import JavaScript code into F#
=====================================

First, make sure that you have the following code in your `fs/Main.fsproj`
file:

```
<Reference Include="../node_modules/fable-core/Fable.Core.dll" />
```

Don't worry: this repository already includes the above code in
`fs/Main.fsproj`

Now you can import `.js` files into `.fs` by using the following attribute:

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

You can see an example in the `fs/Message.fs` file.

This works for any local JavaScript files in the `js` folder, but it also
works for builtin Node.js modules or JavaScript files which have been
downloaded with [`yarn`](https://yarnpkg.com/en/docs/cli/install):

```
[<Import("join", "path")>]
```

```
[<Import("foo", "other-library/foo.js")>]
```

If the file path starts with `.` or `..` then it is local to your project.

If the file path does not start with `.` or `..` then it is an npm package.
That means that it is either a builtin Node.js module (e.g. `path`, `fs`,
etc.) or it is a library in the `node_modules` folder.

How to download JavaScript libraries
====================================

Most JavaScript libraries are stored in npm. If there is an npm package called
`foo` that you want to use in your project, then you can do either of the
following:

* Use [`yarn add --dev foo`](https://yarnpkg.com/en/docs/cli/add)

* Manually edit the `package.json` file and add `foo` to the
  `devDependencies`, then run [`yarn`](https://yarnpkg.com/en/docs/cli/install)

  **Note:** In certain situations you may need to add the package to
  `dependencies` rather than `devDependencies`

Generally the first option is better, but the second option gives you more
precise control.

If a JavaScript library isn't on npm, you can instead use a Git URL:

```
yarn add --dev git+https://foo/bar.git#commit
```

You will need to replace `foo/bar.git` with the URL to the git repository, and
you should also specify a `commit`, which should be a git commit hash. Here is
an example:

```
yarn add --dev git+https://github.com/Pauan/fable-getting-started.git#354a0b13a0d4df61d0cc8615829b238fdd1fbd3e
```

If the git repository is hosted on GitHub, you can instead use a shorter form:

```
yarn add --dev Pauan/fable-getting-started#354a0b13a0d4df61d0cc8615829b238fdd1fbd3e
```

How to upgrade your dependencies
================================

You can use [`yarn outdated`](https://yarnpkg.com/en/docs/cli/outdated) which
will tell you which of your dependencies are out of date.

You can then do either of the following:

* Manually edit `package.json` to use the most up-to-date versions.

* Use [`yarn upgrade foo`](https://yarnpkg.com/en/docs/cli/upgrade) which will
  upgrade to the latest version of the package `foo`, and it will also
  automatically edit `package.json` to use the latest version.

* Use [`yarn upgrade`](https://yarnpkg.com/en/docs/cli/upgrade) which upgrades
  all of your dependencies and also edits `package.json`

Locking down you dependencies
=============================

Whenever you run [`yarn`](https://yarnpkg.com/en/docs/cli/install),
[`yarn add`](https://yarnpkg.com/en/docs/cli/add), or
[`yarn upgrade`](https://yarnpkg.com/en/docs/cli/upgrade), it will create a
[`yarn.lock`](https://yarnpkg.com/en/docs/yarn-lock) file which specifies all
of the libraries that your project depends on, and it also specifies the exact
version for every library.

When using [`yarn`](https://yarnpkg.com/en/docs/cli/install), if a
[`yarn.lock`](https://yarnpkg.com/en/docs/yarn-lock)
file exists, then it will use the versions which are specified in the
[`yarn.lock`](https://yarnpkg.com/en/docs/yarn-lock) file.

You should add the [`yarn.lock`](https://yarnpkg.com/en/docs/yarn-lock) file
into git, because then everybody who downloads your project is guaranteed to
use the exact same versions as you, which helps to prevent bugs.

After making any changes (such as [`yarn add`](https://yarnpkg.com/en/docs/cli/add)
or [`yarn upgrade`](https://yarnpkg.com/en/docs/cli/upgrade)) you should add
the new [`yarn.lock`](https://yarnpkg.com/en/docs/yarn-lock) into git.

By following those steps, your project will always use versions which are
guaranteed to work.

Distributing your project as a library
======================================

You can push your project to a hosting site such as GitHub, or you can
[publish it to npm](https://docs.npmjs.com/misc/developers) by using
[`yarn publish`](https://yarnpkg.com/en/docs/cli/publish)

If somebody else uses your project as a library, everything should work
seamlessly.

If it doesn't work, then they can do one of the following:

* If they are using CommonJS/RequireJS/globals they can import `dist/umd/Main.js`

* If they are using ES2015 modules, they can import `dist/es2015/Main.js`
