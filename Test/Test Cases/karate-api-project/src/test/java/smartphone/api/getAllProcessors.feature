Feature: Test /GetAllProcessors enpoint

Background:
    * configure read('karate-config.js')

Scenario: Verify Response Status Code
    Given url baseUrl + endpoints.getAllBrands
    When method get
    Then status 200

Scenario: Verify Response Body
    Given url baseUrl + endpoints.getAllBrands    
    When method get
    Then status 200
    And match response contains {"processorID": "#number", "processorName": "#string"}

Scenario: Verify Specific Response
    Given url baseUrl + endpoints.getAllBrands
    When method get
    Then status 200
    And match response contains {"processorID": 2, "processorName": "Snapdragon 795"}

Scenario: Verify Response Body - Empty Result
    Given url baseUrl + endpoints.getAllBrands
    When method get
    Then status 200
    And match response == []

Scenario: Verify Response Body - Multiple Processors
    Given url baseUrl + endpoints.getAllBrands
    When method get
    Then status 200
    And match response contains {"processorID": "1", "processorName": "Snapdragon 710"}
    And match response contains {"processorID": "2", "processorName": "Snapdragon 795"}
    And match response contains {"processorID": "3", "processorName": "Snapdragon 8520"}
    And match response contains {"processorID": "4", "processorName": "MediaTek Q1400"}
    And match response contains {"processorID": "5", "processorName": "MediaTek S1575"}
 