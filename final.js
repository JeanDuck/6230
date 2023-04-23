const express = require('express');
const app = express();

const bodyParser = require('body-parser');
app.use(bodyParser.json());

app.get('/greeting/:name', (req, res) => {
  const name = req.params.name; 
  const greeting = `Hello ${name}`; 
  const response = `Welcome ${name}`; 
  res.json({ greeting, response }); 
});

const PORT = 3000; 
app.listen(PORT, () => {
  console.log(`Server running on http://localhost:${PORT}`);
});