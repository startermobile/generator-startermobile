'use strict'
yeoman = require('yeoman-generator')
yosay = require('yosay')
chalk = require('chalk')
path = require('path')
replace = require('replace')

StarterMobileGenerator = yeoman.generators.Base.extend(
    constructor: ->
        yeoman.generators.Base.apply this, arguments

    init: ->
        @log yosay('Welcome to the marvellous ' + chalk.red('Starter Mobile') + ' generator!')
        @templatedata = {}

    askForApplicationName: ->
        done = @async()

        prompts = [{
            name: 'applicationName'
            message: 'What\'s the name of your mobile application?'
        }]

        @prompt prompts, ((props) ->
            @props = props
            # To access props later use this.props.someOption;

            done()
    ).bind(this)

    askForTargetPlatforms: ->
        done = @async()
        prompts = [ {
            type: 'checkbox'
            name: 'targetPlatforms'
            message: 'Would you like to enable this option?'
            choices: [
                'iPhone'
                'Android'
                'Windows Phone'
            ]
        }]

        @prompt prompts, ((props) ->
            @props = props
            # To access props later use this.props.someOption;
            done()
        ).bind(this)

    install: ->
        @sourceRoot path.join(__dirname, './templates/app')
        @fs.copy @templatePath(@sourceRoot()), @destinationPath(@applicationName))

    end: ->
        @log '\n'
        @log 'Your project is now created, you can use the following commands to get going'
        @log chalk.green('    dnu restore')
        @log chalk.green('    dnu build')
        @log chalk.green('    dnx . run') + ' for console projects'
        @log chalk.green('    dnx . kestrel') + ' or ' + chalk.green('dnx . web') + ' for web projects'
)

module.exports = StarterMobileGenerator

# vim: tw=120 ts=4 sw=4 et :
