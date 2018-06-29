module.exports = function (grunt) {

  var path = require('path');
  require('matchdep').filterDev('grunt-*').forEach(grunt.loadNpmTasks);

  var lineBreak = grunt.util.linefeed;
  var bannerHeader =
		"/*!" +
		" * <%= grunt.template.today(\"dddd, mmmm dS, yyyy, hh:MM:ss TT Z\") %>" + lineBreak +
		" * " + lineBreak +
		" * Manifest:" + lineBreak +
		" * ";

  var bannerFooter = lineBreak + " */" + lineBreak;

  grunt.initConfig({
    pkg: grunt.file.readJSON("package.json"),
    dirs: {
      stylesheets: 'css/',
      stylesheetsMinified: 'css/min/',
      less: 'less/',
      scripts: 'js/',
      scriptsMinified: 'js/min/'
    },
    replace: {
      dist: {
        options: {
          patterns: []
        },
        files: []
      }
    },
    concat: {
      options: {
        separator: lineBreak
      },
      coreScripts:
        {
          options: {
            banner: bannerHeader +
              " * <%= grunt.file.expand(grunt.config.process(concat.coreScripts.src)).join('\\n * ') %>" + bannerFooter
          },
          src: [
            "<%= dirs.scripts %>core.js",
            "<%= dirs.scripts %>config.js",
            "<%= dirs.scripts %>engine.js",
            "<%= dirs.scripts %>*.js",
            "!<%= dirs.scripts %>markerclusterer.js",


          ],
          dest: "<%= dirs.scriptsMinified %>core.scripts.src.js"
        },
      plugins:
        {
          options: {
            banner: bannerHeader +
              " * <%= grunt.file.expand(grunt.config.process(concat.plugins.src)).join('\\n * ') %>" + bannerFooter
          },
          src: [
            "<%= dirs.scripts %>libs/*.js",
            "!<%= dirs.scripts %>libs/jquery-1.9.1.min.js",
            "!<%= dirs.scripts %>libs/xjquery.history.js",
            "!<%= dirs.scripts %>libs/markerwithlabel_packed.js",
            "!<%= dirs.scripts %>libs/ie/**/*.js",
            "!<%= dirs.scripts %>libs/src/**/*.js",
            "!<%= dirs.scripts %>libs/less.min.js"
          ],
          dest: "<%= dirs.scriptsMinified %>plugins.js"
        }
    },
    uglify: {
      coreScripts: {
        options: {
          sourceMap: true
        },
        src: "<%= concat.coreScripts.dest %>",
        dest: "<%= dirs.scriptsMinified %>core.scripts.min.js"
      },
      plugins: {
        src: "<%= concat.plugins.dest %>",
        dest: "<%= dirs.scriptsMinified %>plugins.js"
      }
    },
    less: {
      development: {
        options: {
          compress: true,
          sourceMap: false,
          sourceMapURL: 'styles.css.map',
          sourceMapRootpath: '/site.resource/dotdot/',
          yuicompress: false,
          optimization: 2
        },
        files: {
          "<%= dirs.stylesheetsMinified %>styles.css": "<%= dirs.less %>styles.less"
        }
      }
    },
    autoprefixer: {
      development: {
        options: {
          browsers: ['last 3 versions', 'ie 8', 'ie 9']
        },
        files: {
          '<%= dirs.stylesheets %>styles.css': '<%= dirs.stylesheets %>styles.css'
        }
      }
    },
    sprite: {
      all: {
        src: '../sprites/*.png',
        retinaSrcFilter: '../sprites/*@2x.png',
        dest: '../images/sprites.png',
        retinaDest: '../images/sprites@2x.png',
        destCss: '../stylesheets/less/components/generated/sprites.css',
        imgPath: '../../../images/sprites.png',
        retinaImgPath: '../../../images/sprites@2x.png'
      }
    },
    rename: {
      main: {
        files: [{
          src: ['../stylesheets/less/components/generated/sprites.css'],
          dest: '../stylesheets/less/components/generated/sprites.less'
        }]
      }
    },
    watch: {
      scripts: {
        options: {
          livereload: false
        },
        files: ["<%= dirs.scripts %>*.js", "<%= dirs.scripts %>libs/*.js"],
        tasks: ["compileScripts"]
      },
      less: {
        options: {
          livereload: false
        },
        files: ["<%= dirs.less %>*.less", "<%= dirs.less %>/components/*.less"],
        tasks: ["compileLess"]
      }
    }
  });

  grunt.registerTask('compile', [
    'sprite',
    'rename',
    'replace',
    'less:development',
    'autoprefixer:development',
    'concat:coreScripts',
    'concat:plugins',
    'uglify:coreScripts',
    'uglify:plugins'
  ]);

  grunt.registerTask('dev', [
    'sprite',
    'rename',
    'replace',
    'less:development',
    'concat:coreScripts',
    'concat:plugins',
    'uglify:coreScripts',
    'uglify:plugins'
  ]);

  grunt.registerTask('compileSprites', [
		'sprite',
		'rename',
		'replace'
  ]);

  grunt.registerTask('compileScripts', [
    'concat:coreScripts',
    'concat:plugins',
    'uglify:coreScripts',
    'uglify:plugins'
  ]);

  grunt.registerTask('compileLess', [
      'less:development'
  ]);

  grunt.registerTask("watchScripts", [
		"compileScripts",
		"watch:scripts"
  ]);

  grunt.registerTask("watchLess", [
		"compileLess",
		"watch:less"
  ]);

};
