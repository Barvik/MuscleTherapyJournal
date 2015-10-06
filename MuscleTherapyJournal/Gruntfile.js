/*global module:false*/
module.exports = function (grunt) {
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),

        less: {
            development: {
                options: {
                    paths: ["components"],
                    ieCompat: true,
                    relativeUrls: true
                },
                files: {
                    /*Just moving the MDS CSS files we got now, when we compile the less ourself it doesn't work. */
                    "Content/treatment.css": "less/treatment.less"
                }
            }
        },
        watch: {
            styles: {
                files: ['less/*.less', 'less/*/*.less', 'mdx/less/*.less', 'components/**/*.less'],
                tasks: ['less'],
                options: {
                    spawn: false,
                    livereload: true
                }
            }/*,
    gruntfile: {
      files: '<%= jshint.gruntfile.src %>',
      tasks: ['jshint:gruntfile']
    }*/
        }
    });

    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-less');

    grunt.registerTask('default', ['watch']);
};