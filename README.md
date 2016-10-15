Fable Quick Start
=================

It can be difficult to figure out how to properly setup [Fable](http://fable.io/).

This repository contains fully working code, so it is easy to get started.

In addition, it also shows how to do the following:

* Import local JavaScript code into F#

* Download JavaScript libraries and then import them into F#

* Run your project as an application in either a browser or [Node.js](https://nodejs.org/)

Downloading the project
=======================

Make sure you have Git installed, and then use the following command in a
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

Make sure that you have [`node`](https://nodejs.org/) and
[`yarn`](https://yarnpkg.com/) installed.

You can get [`yarn`](https://yarnpkg.com/) from
[its website](https://yarnpkg.com/en/docs/install), or alternatively you can
use the following command:

```
npm install --global yarn
```

Now you must use [`yarn install`](https://yarnpkg.com/en/docs/cli/install),
which will download all of the necessary dependencies for the project.

After the dependencies are downloaded, it will then automatically compile your
project.

**Note:** you can instead use [`yarn`](https://yarnpkg.com/en/docs/cli/install),
which is exactly the same as [`yarn install`](https://yarnpkg.com/en/docs/cli/install)

You do not need to install [Fable](http://fable.io/) globally:
[Fable](http://fable.io/) will be installed locally inside of the
`node_modules` folder. This makes it easier for other people to contribute to
your project because they do not need to install [Fable](http://fable.io/)
globally, and it also guarantees that everybody is compiling your project with
the correct version of [Fable](http://fable.io/).

Customization
=============

You will probably want to change these properties in the
[`package.json`](https://yarnpkg.com/en/docs/package-json) file:

* `name`

* `description`

* `version`

* `license`

You can use whatever name you want for your project, as long as nobody else
has taken the name first.

Compiling your project
======================

Your project is automatically compiled when you use
[`yarn`](https://yarnpkg.com/en/docs/cli/install)

You can instead use [`yarn run watch`](https://yarnpkg.com/en/docs/cli/run),
which will compile your project (just like
[`yarn`](https://yarnpkg.com/en/docs/cli/install)), but it will also
automatically recompile your project if you make any changes to the `.fs` or
`.js` files.

If you want to stop watch mode, just hit the `Enter` or `Return` key.

Watch mode is very convenient, and it's also **much** faster, because it only
recompiles the files that actually changed, rather than recompiling your
entire project from scratch.

After making a minor change to a single `.fs` file,
[`yarn`](https://yarnpkg.com/en/docs/cli/install) takes 4,000
milliseconds to recompile the project, but
[`yarn run watch`](https://yarnpkg.com/en/docs/cli/run) takes only 40
milliseconds! The times may be slower or faster depending on your computer,
but watch mode is always faster than a full compile.

Running your project
====================

After compiling, the final JavaScript code will be in the `dist/umd/Main.js`
file.

* If you want to run it in a browser, you can open the `dist/index.html` file
  in any browser. You will need to open your browser's web console in order to
  see the output.

  It uses a standard HTML `<script>` tag to load the `dist/umd/Main.js` file:

  ```
  <script src="umd/Main.js"></script>
  ```

* If you want to run it in [Node.js](https://nodejs.org/), you can use
  `node .` or `node dist/umd/Main.js` (they both do the same thing)

Making changes to the project
=============================

You can modify the `.fs` files in the `fs` folder, and you can modify the
`.js` files in the `js` folder.

The `.fs` files are F# code, which will be compiled by [Fable](http://fable.io/).

The `.js` files are JavaScript code, which will be compiled by
[Babel](https://babeljs.io/) and will be bundled into your compiled code.

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
everything else.

How to download JavaScript libraries
====================================

Most JavaScript libraries are stored in [npm](https://www.npmjs.com/). If
there is an [npm](https://www.npmjs.com/) package called `foo` that you want
to use in your project, then you can do either of the following:

* Use [`yarn add --dev foo`](https://yarnpkg.com/en/docs/cli/add)

* Manually edit the [`package.json`](https://yarnpkg.com/en/docs/package-json)
  file and add `foo` to the
  [`devDependencies`](https://yarnpkg.com/en/docs/package-json#toc-devdependencies),
  then use [`yarn`](https://yarnpkg.com/en/docs/cli/install)

  **Note:** In certain situations you may need to add the package to
  [`dependencies`](https://yarnpkg.com/en/docs/package-json#toc-dependencies)
  rather than
  [`devDependencies`](https://yarnpkg.com/en/docs/package-json#toc-devdependencies)

Usually the first option is better, but the second option gives you more
precise control.

----

If a JavaScript library isn't on [npm](https://www.npmjs.com/), you can
instead use a Git URL:

```
yarn add --dev https://foo/bar.git
```

You will need to replace `https://foo/bar.git` with the URL to the Git
repository. Here is an example:

```
yarn add --dev https://github.com/fable-compiler/fable-react.git
```

If the Git repository is hosted on GitHub, you can instead use the shorter
form `author/name`, like this:

```
yarn add --dev fable-compiler/fable-react
```

When using a Git URL, you can also specify a particular commit hash or branch
by adding a `#` at the end, like this:

```
yarn add --dev https://github.com/fable-compiler/fable-react.git#3df6ff3422dae06f206e7307a3b3eb8fbf5b610c
yarn add --dev https://github.com/fable-compiler/fable-react.git#master
```

This also works with the shorter GitHub form:

```
yarn add --dev fable-compiler/fable-react#3df6ff3422dae06f206e7307a3b3eb8fbf5b610c
yarn add --dev fable-compiler/fable-react#master
```

How to import JavaScript code into F#
=====================================

First, make sure that you have the following code in your `fs/Main.fsproj`
file:

```
<Reference Include="../node_modules/fable-core/Fable.Core.dll" />
```

Don't worry: this repository already includes the above code in
`fs/Main.fsproj`

Now you can import `.js` files into `.fs` files by using the
`Fable.Core.Import` attribute:

```
[<Fable.Core.Import("foo", "/js/foo.js")>]
let foo: string = jsNative
```

**Note:** You have to specify the type of the variable, and its value should
usually be `jsNative`

If you are using a lot of imports you can do this:

```
open Fable.Core
```

Now you no longer need the `Fable.Core` prefix when importing:

```
[<Import("foo", "/js/foo.js")>]
let foo: string = jsNative
```

You can see an example in the `fs/Message.fs` file.

This works for any local JavaScript files in the `js` folder, but it also
works for builtin [Node.js](https://nodejs.org/) modules or
[npm](https://www.npmjs.com/) packages which have been downloaded with
[`yarn`](https://yarnpkg.com/en/docs/cli/install):

```
[<Import("join", "path")>]
```

```
[<Import("foo", "some-library/foo.js")>]
```

If the file path starts with `/` then it is relative to your project
directory.

If the file path starts with `.` or `..` then it is relative to the `.fs` file
which contains the `Import`

If the file path does not start with `/` or `.` or `..` then it is an
[npm](https://www.npmjs.com/) package. That means that it is either a builtin
[Node.js](https://nodejs.org/) module (e.g.
[`path`](https://nodejs.org/dist/latest-v6.x/docs/api/path.html),
[`fs`](https://nodejs.org/dist/latest-v6.x/docs/api/fs.html), etc.) or it is
a dependency which is listed in the
[`package.json`](https://yarnpkg.com/en/docs/package-json) file.

How to upgrade your dependencies
================================

You can use [`yarn outdated`](https://yarnpkg.com/en/docs/cli/outdated) which
will tell you which of your project's dependencies are out of date.

You can then do one of the following:

* Use [`yarn upgrade foo`](https://yarnpkg.com/en/docs/cli/upgrade) which will
  upgrade the package `foo` to the latest version, and it will also
  automatically edit [`package.json`](https://yarnpkg.com/en/docs/package-json)
  to use the latest version for `foo`

* Use [`yarn upgrade`](https://yarnpkg.com/en/docs/cli/upgrade) which upgrades
  *all* of your dependencies to the latest version, and also edits
  [`package.json`](https://yarnpkg.com/en/docs/package-json) to use the latest
  versions.

* Manually edit [`package.json`](https://yarnpkg.com/en/docs/package-json) to
  use the latest versions, and then use
  [`yarn`](https://yarnpkg.com/en/docs/cli/install)

How to remove a dependency
==========================

You can do one of the following:

* Use [`yarn remove foo`](https://yarnpkg.com/en/docs/cli/remove) which will
  remove the package `foo`, and it will also automatically remove `foo` from
  the [`package.json`](https://yarnpkg.com/en/docs/package-json) file.

* Manually edit [`package.json`](https://yarnpkg.com/en/docs/package-json) to
  remove the `foo` package`, and then use
  [`yarn`](https://yarnpkg.com/en/docs/cli/install)

Locking down you dependencies
=============================

Whenever you use [`yarn`](https://yarnpkg.com/en/docs/cli/install),
[`yarn add`](https://yarnpkg.com/en/docs/cli/add),
[`yarn upgrade`](https://yarnpkg.com/en/docs/cli/upgrade), or
[`yarn remove`](https://yarnpkg.com/en/docs/cli/remove), it will create a
[`yarn.lock`](https://yarnpkg.com/en/docs/yarn-lock) file which specifies all
of the dependencies that your project depends on, and it also specifies the
exact version for every dependency.

When using [`yarn`](https://yarnpkg.com/en/docs/cli/install), if a
[`yarn.lock`](https://yarnpkg.com/en/docs/yarn-lock)
file exists, then it will use the versions which are specified in the
[`yarn.lock`](https://yarnpkg.com/en/docs/yarn-lock) file.

You should add the [`yarn.lock`](https://yarnpkg.com/en/docs/yarn-lock) file
into Git, because then everybody who downloads your project is guaranteed to
use the exact same versions as you, which helps to prevent bugs.

After making any changes (such as [`yarn add`](https://yarnpkg.com/en/docs/cli/add)
or [`yarn upgrade`](https://yarnpkg.com/en/docs/cli/upgrade)) you should add
the new [`yarn.lock`](https://yarnpkg.com/en/docs/yarn-lock) into Git.

By following those steps, your project will always use versions which are
guaranteed to work.
