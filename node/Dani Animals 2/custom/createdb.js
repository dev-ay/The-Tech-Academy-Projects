// Using mLab, connect the database to mongodb shell
// http://docs.mlab.com/connecting/#mongo-shell
// use this code to past into the shell to add entries
// one section at a time

newstuff = [
    {
        "name": "Carl",
        "age": "4",
        "type": "Fox"
    },
    {
        "name": "Peter Douglass",
        "age": "3",
        "type": "Red Panda"
    },
    {
        "name": "Bunny",
        "age": "1",
        "type": "Bunny"
    }
]; 

db.usercollection.insert(newstuff)