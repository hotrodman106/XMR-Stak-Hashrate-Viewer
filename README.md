# XMR-Stack-Hashrate-Viewer
A utility for displaying multiple XMR-Stak miner's hashrates.

## How do I use the thing?
I'm glad you asked! Pay attention to the following:

### Prerequisites
In order to use this software, you **MUST** be using XMR-Stak as your mining software. If you have gone this far and don't know what software you're using, then you are on your own. Once that's out of the way, you must configure XMR-Stak to use the webserver with or without login credentials. (visit the XMR-Stak Github page at: https://github.com/fireice-uk/xmr-stak for more info)

### Using the Software
Once you have the prerequisites out of the way, the first step is to add your miner. Select the 'Add Miner' button and type the ip address and port (if applicable) for your miner's webserver (I.E. 10.0.0.42 or 201.54.32.333:8080). If the miner is secured, a pop-up prompting for a username and password will appear. After your miner is added, select a refresh time from the dropdown on the right side of the screen. By default, the client will pool the server every five seconds however, you can set this anywhere from one second up to ten seconds. If you want to remove a miner, simply click the red x next to the miner's IP address.

## How do I read the thing?
I'm glad you asked! Pay attention to the following:

### Main Window
In the main window, each miner's hashrates, connection, version, and results data will be displayed. These values will be updated at every refresh interval.

### Highest Total Hashrate Window
In the highest total hashrate window, the sum of the highest hashrates across **ALL** miners will be displayed. This value is updated whenever the highest hashrate values from any miners are changed.

### Total Hashrate Window
In the total hashrate window, the total hashrate across **ALL** miners will be displayed. This value is updated at every refresh interval.

### Monero Price Window
In the monero price window, the current market value of monero is displayed. This value is updated every refresh interval unless your refresh interval is one second. In that case, the value is updated every two seconds instead. This data is obtained using the Nanopool Monero API (https://xmr.nanopool.org/api).

### Estimated Weekly Revenue Window
In the estimated weekly revenue window, the estimated weekly revenue is displayed as calculated using the **TOTAL** hashrate and the **NANOPOOL POOL VALUES**. This value is updated every refresh interval unless your refresh interval is one second. In that case, the value is updated every two seconds instead. This data is obtained using the Nanopool Monero API (https://xmr.nanopool.org/api).

## Program Screenshots
![GUI1](https://raw.githubusercontent.com/hotrodman106/XMR-Stak-Hashrate-Viewer/master/XMRStakData/Docs/MainScreen.png)
![GUI2](https://raw.githubusercontent.com/hotrodman106/XMR-Stak-Hashrate-Viewer/master/XMRStakData/Docs/AddMinerScreen.png)
![GUI3](https://raw.githubusercontent.com/hotrodman106/XMR-Stak-Hashrate-Viewer/master/XMRStakData/Docs/LoginScreen.png)

## Buy Me a Beer
Monero: 41mkhbZFybM9wBiT4wHzFX17gZukZo9qQZKNJLRwVMb8V2cE8iyNNdHgfbfnzmr8Ej38yGADHV5m6MnQaLie1Yx976UQhXg
