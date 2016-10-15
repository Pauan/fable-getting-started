import nodeResolve from "rollup-plugin-node-resolve";
import commonjs from "rollup-plugin-commonjs";
import sourcemaps from "rollup-plugin-sourcemaps";
import babel from "rollup-plugin-babel";
import root from "rollup-plugin-root-import";

export default {
  moduleName: "Main",
  entry: "./.build/Main.js",
  sourceMap: true,

  targets: [
    { dest: "./dist/umd/Main.js", format: "umd" },
    { dest: "./dist/es2015/Main.js", format: "es" }
  ],

  plugins: [
    root({
      root: __dirname
    }),

    nodeResolve(),

    commonjs({
      include: "./node_modules/**"
    }),

    sourcemaps(),

    babel({
      include: ["./js/**", "./.build/**"]
    })
  ]
};
