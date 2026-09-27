Feature: Bank Manager Operations
  As a Bank Manager
  I want to manage the customer list
  So that I can easily find customers by sorting their data

Scenario: Sort customers by Post Code
  Given I navigate to the XYZ Bank home page
  When I click on the "Bank Manager Login" button
  And I click on the "Customers" tab
  And I click on the "Post Code" column header
  Then the customer list should be sorted by Post Code