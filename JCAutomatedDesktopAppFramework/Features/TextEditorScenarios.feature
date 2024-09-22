Feature: TextEditorScenarios

As a user I want to be able to input text into a Notepad file, and ensure I can edit it

Background: User has opened the application
	Given I launch Notepad
	And the editor opens on a blank screen

Scenario: Basic text entry works
	When I type: "Basic text input example"
	Then I can see that the text has been updated in the editor to: "Basic text input example"
	And the file name on the tab has been updated accordingly to: "Basic text input example"
	And I can close the tab

	Scenario: User can delete inputted text
	Given I type: "Basic text input example"
	When I delete the word "example"
	Then I can see that the text has been updated in the editor to: "Basic text input"
	And the file name on the tab has been updated accordingly to: "Basic text input"
	And I can close the tab

	Scenario: User can use Col functionality to track cursor position
	Given I type: "A diffrent text input example for Col functionality testing"
	And I note the current Col position of "60"
	When I hit the "Left arrow" key "5" times
	Then The Col position is updated to be "55"
	And I can close the tab

	Scenario: User can use Ln functionality to track cursor position
	Given I type: "A diffrent text input example for Line functionality testing"
	And I note the current Ln position of "1"
	When I hit the "enter" key "3" times
	Then The Ln position is updated to be "4"
	And I can close the tab