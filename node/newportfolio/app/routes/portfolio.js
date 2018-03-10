var express = require('express');
var router = express.Router();

router.get('/portfolio', function(req, res) {
    res.render('portfolio', {
        siteTitle: 'Joshua Hunsche Jones',
        pageTitle: 'Portfolio'
    });
});

module.exports = router;