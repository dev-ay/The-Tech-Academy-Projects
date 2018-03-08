var express = require('express');
var reload = require('reload');
var app = express();
var dataFile = require('./data/data.json');

// these make a variable avaiable to the entire application
app.set('port', process.env.PORT || 3000);
app.set('appData', dataFile);
// setting the view engine and views folder
app.set('view engine', 'ejs');
app.set('views', 'app/views');

// static middleware allows any one of my files to access these public files
app.use(express.static('app/public'));
// here is how I pull back in my routes
app.use(require('./routes/index'));
app.use(require('./routes/portfolio'));


var server = app.listen(app.get('port'), function () {
    console.log('Listening on port ' + app.get('port'));
});

reload(server, app);
