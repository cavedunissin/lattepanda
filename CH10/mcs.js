var mcs = require('mcsjs');
var SerialPort = require("serialport").SerialPort
var serialPort = new SerialPort("COMX",
{baudrate: 9600
});

var myApp = mcs.register({
        deviceId: 'your device ID',
        deviceKey: 'your device Key',
});

serialPort.on("open", function () {
        receivedData ="";
        serialPort.on('data',function(data)
        {
                receivedData =data.toString();
                a = receivedData.length;
                myApp.emit('sensor','', receivedData.substring(2,a));
                //從字串的2號位置取長度a，即可取得資料本身
        });
});
