Feature: Test /GetAllProcessors enpoint

Background:
    * url 'https://localhost:5002'

Scenario: Verify Response Status Code
    Given path '/GetAllProcessors'
    When method get
    Then status 200

Scenario: Verify Response Body
    Given path '/GetAllProcessors'    
    When method get
    Then status 200
    And match response contains {"processorID": "#number", "processorName": "#string"}

Scenario: Verify Specific Response
    Given path '/GetAllProcessors'
    When method get
    Then status 200
    And match response contains {"processorID": 2, "processorName": "Snapdragon 795"}

Scenario: Verify Response Body - Empty Result
    Given path '/GetAllProcessors'
    When method get
    Then status 200
    And match response == []

Scenario: Verify Response Body - Multiple Processors
    Given path '/GetAllProcessors'
    When method get
    Then status 200
    And match response contains {"processorID": "1", "processorName": "Snapdragon 710"}
    And match response contains {"processorID": "2", "processorName": "Snapdragon 795"}
    And match response contains {"processorID": "3", "processorName": "Snapdragon 8520"}
    And match response contains {"processorID": "4", "processorName": "MediaTek Q1400"}
    And match response contains {"processorID": "5", "processorName": "MediaTek S1575"}
 