import nodeResolve from "rollup-plugin-node-resolve";
import commonjs from "rollup-plugin-commonjs";
import sourcemaps from "rollup-plugin-sourcemaps";
import babel from "rollup-plugin-babel";

export default {
  moduleName: "fableQuickStart",
  entry: "./.build/main.js",
  sourceMap: true,

  targets: [
    { dest: "./dist/umd/main.js", format: "umd" },
    { dest: "./dist/es2015/main.js", format: "es" }
  ],

  plugins: [
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
