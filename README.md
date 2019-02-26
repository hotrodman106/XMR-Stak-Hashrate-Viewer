# XMR-Stack-Hashrate-Viewer
A utility for displaying multiple XMR-Stak miner's hashrates.

## How do I use the thing?
I'm glad you asked! Pay attention to the following:

### Prerequisites
In order to use this software, you **MUST** be using XMR-Stak as your mining software. If you have gone this far and don't know what software you're using, then you are on your own. Once that's out of the way, you must configure XMR-Stak to use the webserver **WITHOUT** login credentials. (visit the XMR-Stak Github page at: https://github.com/fireice-uk/xmr-stak for more info)

### Using the Software
Once you have the prerequisites out of the way, the first step is to add your miner. Select the 'Add Miner' button and type the ip address and port for your miner's webserver (I.E. 10.0.0.42:80 or 201.54.32.333:8080). After your miner is added, select a refresh time from the dropdown on the right side of the screen. By default, the client will pool the server every five seconds however, you can set this anywhere from one second up to ten seconds. If you want to remove a miner, simply click the red x next to the miner's IP address.

## How do I read the thing?
I'm glad you asked! Pay attention to the following:

### Main Window
In the main window, each core's respective hashrate will be displayed along with the highest and total hashrates. These values will be updated at every refresh interval.

### Highest Total Hashrate Window
In the highest total hashrate window, the sum of the highest hashrates across **ALL** miners will be displayed. These values are updated whenever the highest hashrate values from any miners are changed.

### Total Hashrate Window
In the total hashrate window, the total hashrate across **ALL** miners will be displayed. These values are updated at every refresh interval.
