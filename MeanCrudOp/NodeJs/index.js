const express = require('express');
const bodyParser = require('body-parser');

const { mongoose } = require('./db.js');
var employeeController = require('./controllers/employeeController.js');

var app = express();
app.use(bodyParser.json());

app.listen(3000, () => console.log('Servert estaretd at port : 3000'));

app.use('/employees', employeeController);
