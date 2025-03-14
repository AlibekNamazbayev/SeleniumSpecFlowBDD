Feature: Login Functionality
  As a registered user
  I want to login successfully
  So that I can access secure content

  Scenario: Successful Login
    Given I am on the login page
    When I enter valid credentials
    Then I should be redirected to the secure area
