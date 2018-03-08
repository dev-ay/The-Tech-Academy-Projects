var express = require('express');
var router = express.Router();

router.get('/portfolio', function(req, res) {
    var info = '';
    // we set this in app.js and now we are getting it back
    var dataFile = req.app.get('appData');
    dataFile.speakers.forEach(function(item) {
        info += 
        `<li> <h2>${item.name}</h2> <p>${item.summary}</p> </li>`
    })
    res.send(`
        <h1>Portfolio Website</h1>
        ${info}
        <script src="/reload/reload.js"></script>
    `);
});

// this : notation is how you pass in a varaible to the rout!
router.get('/portfolio/:projectid', function(req, res) {
    // we set this in app.js and now we are getting it back
    var dataFile = req.app.get('appData');
    // this params object allows us to access any variables that we pass long though the url
    var speaker = dataFile.speakers[req.params.projectid]
    res.send(`
        <h1>${speaker.title}</h1>
        <h2>${speaker.name}</h2>
        <p>${speaker.summary}</p>
        <script src="/reload/reload.js"></script>
    `);
});

module.exports = router;