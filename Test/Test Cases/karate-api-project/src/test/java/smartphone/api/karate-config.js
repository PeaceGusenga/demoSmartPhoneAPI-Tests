function fn() {
    var config = {
      baseUrl: 'https://localhost:5002',
      endpoints: {
        getAllBrands: '/GetAllBrands',
        getAllProcessors: '/GetAllProcessors',
        getAllSmartphones: '/GetAllSmartphones',
        addProcessors: '/AddProcessors',
      }
    };
    return config;
  }
  