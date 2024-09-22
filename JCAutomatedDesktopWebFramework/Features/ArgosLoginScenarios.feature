Feature: ArgosLoginScenarios

As an Argos customer I want to be able to store my information in an account for ease of purchasing, and for this information to be securely held so only I can view it

Background: A customer navigates from home page to login page
	Given I am on the "home" page
	But I am not logged in
	And I navigate to the account page

Scenario: A customer can navigate to the account registration form
	When I opt to register an account
	Then I will see an area to begin registering my details

Scenario: if a customer forgets their password then there is a way to start a process to reset it
	When I indicate that I've forgotten my password
	Then I arrive on an apprpriate page to reset my password

Scenario: user with valid credentials can login
	Given I enter valid account credentials
	When I attempt to sign into my account
	Then I am logged in to my account

Scenario: user with invalid credentials can't login
	Given I enter invalid account credentials
	When I attempt to sign into my account
	Then I am not logged in to my account

Scenario: user is able to sign out of their account once logged in
	Given I log into my account
	When I sign out of my account
	Then I can see I am logged out
