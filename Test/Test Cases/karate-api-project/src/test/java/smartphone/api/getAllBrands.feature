Feature: Test /GetAllBrands enpoint

Background:
    * configure read('karate-config.js')

Scenario: Verify Status Code
    Given url baseUrl + endpoints.getAllBrands
    When method get
    Then status 200

Scenario: Verify Response Body has Expected Structure
    Given url baseUrl + endpoints.getAllBrands
    When method get
    Then status 200
    And match response == 
    """
    [
        {
            "BrandID": "#number",
            "BrandName": "#string",
            "BrandNetWorth": "#number"
        }
    ]
    """

Scenario: Verify Response Body - Empty Result
    Given url baseUrl + endpoints.getAllBrands
    When method get
    Then status 200
    And match response == []
