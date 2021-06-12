const { MongoClient } = require("mongodb");
const uri = "mongodb://localhost:27017/";
const client = new MongoClient(uri, {
  useNewUrlParser: true,
  useUnifiedTopology: true,
});

async function run() {
  try {
    await client.connect();
    
    var databasesList = await client.db().admin().listDatabases();
    databasesList.databases.forEach(element => {
        if(element.name === "CarParts"){
            throw "Error: Database already exists";
        }
    });

    const dbo = client.db('CarParts');

    dbo.createCollection("Wheels");
    dbo.createCollection("Suspension");
    dbo.createCollection("Engine");
    dbo.createCollection("Cars");
    dbo.createCollection("Clients");

    // #region Wheels
    var wheel1 = { name: "Vossen", model: "HF-5", diameter: 20, vin: "1001, 1004", price: 5000 };
    var wheel2 = { name: "Vossen", model: "CVT", diameter: 22, vin: "1002,1004", price: 6000 };
    var wheel3 = { name: "Rotiform", model: "CCV", diameter: 19, vin: "1001,1003,1005", price: 4000 };
    var wheel4 = { name: "ZPerformance", model: "ZP.Forged Mono 1", diameter: 22, vin: "1002,1004", price: 5000 };
    var wheel5 = { name: "ZPerformance", model: "ZP.Forged R", diameter: 20, vin: "1001,1004", price: 6000 };
    
    dbo.collection("Wheels").insertOne(wheel1);
    dbo.collection("Wheels").insertOne(wheel2);
    dbo.collection("Wheels").insertOne(wheel3);
    dbo.collection("Wheels").insertOne(wheel4);
    dbo.collection("Wheels").insertOne(wheel5);
    // #endregion

    // #region Suspension
    var sus1 = { name: "Ohlins", model: "Amortyzator przedni VWS", purpose: "sport", vin: "1001, 1004", price: 1000 };
    var sus2 = { name: "Ohlins", model: "Amortyzator przedni AUS", purpose: "sport", vin: "1001,1004", price: 900 };
    var sus3 = { name: "Sachs", model: "Amortyzator przedni", purpose: "casual", vin: "1002,1003,1004", price: 200 };
    var sus4 = { name: "Sachs", model: "Sprężyna amortyzatora 291mm", purpose: "sport", vin: "1003", price: 200 };
    var sus5 = { name: "Sachs", model: "Sprężyna amortyztora 363mm", purpose: "casual", vin: "1001,1002", price: 150 };

    dbo.collection("Suspension").insertOne(sus1);
    dbo.collection("Suspension").insertOne(sus2);
    dbo.collection("Suspension").insertOne(sus3);
    dbo.collection("Suspension").insertOne(sus4);
    dbo.collection("Suspension").insertOne(sus5);
    // #endregion

    // #region Engine
    var eng1 = { name: "Garrett", model: "Turbosprężarka Super Core", purpose: "sport", vin: "1002", price: 9000 };
    var eng2 = { name: "Garrett", model: "Turbosprężarka Gen 2 Core", purpose: "sport", vin: "1002,1003", price: 10000 };
    var eng3 = { name: "Volkswagen", model: "Turbosprężarka 1,9TDI", purpose: "casual", vin: "1001,1004", price: 700 };
    var eng4 = { name: "Bosch", model: "Sonda lambda F00H", purpose: "casual", vin: "1005", price: 200 };
    var eng5 = { name: "Mann Filter", model: "Filtr oleju TDI", purpose: "sport", vin: "1001,1005,1004", price: 50 };

    dbo.collection("Engine").insertOne(eng1);
    dbo.collection("Engine").insertOne(eng2);
    dbo.collection("Engine").insertOne(eng3);
    dbo.collection("Engine").insertOne(eng4);
    dbo.collection("Engine").insertOne(eng5);
    // #endregion

    // #region Cars
    var car1 = { name: "Audi", model: "A7 S Line", carId: "1", vin: "1002", year: 2019 };
    var car2 = { name: "Mercedes", model: "E 220d", carId: "2", vin: "1003", year: 2018 };
    var car3 = { name: "BMW", model: "M4 Competition", carId: "3", vin: "1004", year: 2018 };
    var car4 = { name: "Volkswagen", model: "Arteon", carId: "5", vin: "1005", year: 2017 };
    var car5 = { name: "Land Rover", model: "Range Rover Evoque", carId: "4", vin: "1001", year: 2014 };

    dbo.collection("Cars").insertOne(car1);
    dbo.collection("Cars").insertOne(car2);
    dbo.collection("Cars").insertOne(car3);
    dbo.collection("Cars").insertOne(car4);
    dbo.collection("Cars").insertOne(car5);
    // #endregion

    // #region Clients
    var cli1 = { name: "Jan Kowalski", address: "Wiejska 45A, Białystok", car: "2", phone: "123456789" };
    var cli2 = { name: "Paweł Szumski", address: "Zachodnia 8, Białystok", car: "1", phone: "987654321" };
    var cli3 = { name: "Robert Kubica", address: "Mazowiecka 27, Warszawa", car: "3", phone: "123654789" };
    var cli4 = { name: "Michał Głuś", address: "Wesoła 8, Zarzygadło", car: "5", phone: "789654123" };
    var cli5 = { name: "Mariola Śryż", address: "Kwiatowa 1, Buda Ruska", car: "4", phone: "432567891" };

    dbo.collection("Clients").insertOne(cli1);
    dbo.collection("Clients").insertOne(cli2);
    dbo.collection("Clients").insertOne(cli3);
    dbo.collection("Clients").insertOne(cli4);
    dbo.collection("Clients").insertOne(cli5);
    // #endregion
  } 
  catch(err) {
    console.log("Database init failed");
    console.log(err);
  }
  finally {
    console.log("Deployment reached end");
  }
}

run().catch(console.dir);