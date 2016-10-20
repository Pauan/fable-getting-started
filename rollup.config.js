var sourcemaps = require("rollup-plugin-sourcemaps");
var babel      = require("rollup-plugin-babel");

module.exports = {
  dest: "./dist/umd/Main.js",

  /*targets: [
    { dest: "./dist/umd/Main.js", format: "umd" },
    { dest: "./dist/es2015/Main.js", format: "es" }
  ],*/

  plugins: [
    sourcemaps(),

    babel({
      include: ["./src/js/**"]
    })
  ]
};
