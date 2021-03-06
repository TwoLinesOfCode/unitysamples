var io = require('socket.io')(process.env.PORT || 3000);
console.log('server started');

io.on('connection', function(socket){
    console.log('client connected');

    socket.broadcast.emit('spawn'); //broadcast to all other connected clients.

    socket.on('move', function(data){
        console.log('client moved');
    });
})
