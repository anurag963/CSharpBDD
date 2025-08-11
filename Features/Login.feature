Feature: Login functionality

@mytag
Scenario: Successful login
	Given user is on the Home page
    Then user is on the login page
    When user should be able to login with valid credentials
    Then user should be redirected to the homepage
    And user should be able to see "Logout" link