Feature: SettingsScenarios

As an end user I want to be able to view a settings panel to check and configure the application to my liking

Scenario: Settings icon opens settings menu
    Given I launch Notepad
    When I select the "Settings" icon
    Then I will see the settings menu

Scenario: Validate Notepad version
    Given I launch Notepad
    When  I select the "Settings" icon
    Then I will be able to verify the version number as "11.2312.18.0"
