const express = require('express');
const bodyParser = require('body-parser');

const app = express();
app.use(bodyParser.json());


app.get('', (req, res) => {
  const name = req.query.name;
  console.log(name);
  
  if (name) {
    res.send("Welcome " + name + "\n");
  } else {
    res.end("Hello World \n");
  }
});

app.get('/user',(req,resp)=>{
    const user = {
        "userName":"Zhiwei",
        "id": 1234

    }
    const data = JSON.stringify(user)
    resp.send(data)
})


const port = 3000;
app.listen(port, () => {
  console.log(`Server is running on port ${port}`);
});
//http://localhost:3000/?name=zhiwei

