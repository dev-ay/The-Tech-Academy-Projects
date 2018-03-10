var express = require('express');
var router = express.Router();

router.get('/', function(req, res) {
    res.render('index', {
        siteTitle: 'Joshua Hunsche Jones',
        pageTitle: 'Home'
    });
});

module.exports = router;