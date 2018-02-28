var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res, next) {
  res.render('index', { title: 'Express' });
});

// GET Hello World Page 
router.get('/helloworld', function(req, res) {
  res.render('helloworld', { title: "Hello, World!" });
});

// GET Animals page
router.get('/animals', function(req, res) {
  var db = req.db;
  var collection = db.get('usercollection');

  collection.find({},{}, function(e, docs) {
    res.render('animals', {
      "animals" : docs
    });
  });
});

// GET New Animal page
router.get('/newanimal', function(req, res) {
  res.render('newanimal', { title: 'Add New Animal' })
});

// POST for new animals
router.post('/newanimal', function(req, res) {
  var db = req.db;
  var animalName = req.body.animalname;
  var animalAge = req.body.animalage;
  var animalType = req.body.animaltype;
  
  var collection = db.get('usercollection');

  // Submit to the database
  if (animalName != "" || animalAge != "" || animalType != "") {
    collection.insert({
      "name": animalName,
      "age": animalAge,
      "type": animalType
    }, function (err, doc) {
      if (err) {
        res.send("There was a problem adding your information to the database.")
      }
      else {
        res.redirect("animals")
      }
    });
  }
  else {
    console.log("attempted to add empty field")
    res.send(`<br/><p>There was a problem adding your information to the database.</p><p>Please fill in all the fields. Hit back to try again!</p>`)
  }
});

module.exports = router;
