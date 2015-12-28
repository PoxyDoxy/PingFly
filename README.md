# PingFly (.exe)
## What this does
PingFly helps you monitor your Internet Connection on the fly, which is helpfull when gaming or doing important tasks. 
To Keep results accurate and clean, It pings multiple servers at the same time to help you locate your Internet Fault.
It measures the latency of up to 6 servers, with features such as:
- Statistics:
  - Live Average (Average of current ping to servers).
  - Total Average (Average of all pings sent to servers).
  - Min Latency (Minimum Latency ever recorded, and which server it happened on).
  - Max Latency (Maximum Latency ever recorded, and which server it happened on).
  - Lost Packets + Sent Packets
- 8 PreSet Location Based Server Lists (Choose the closest near you).
  - Perth
  - Adelaide
  - Sydney
  - Brisbane
  - San Francisco
  - Los Angeles
  - Paris
  - Singapore
- Lets you monitor your internet 
- Easy Updating to the latest version (only requires 2 clicks).
Updater is not enforced, and does not hasstle the user at startup.
- Contains Easter Egg (Super Obvious if you read the code).

## Back End
PingFly updates itself through the WebServer backend, which contains:
- Latest __PingFly.exe__ build
- File containting latest version number
- Current User Counter (Counts people active within last 10 minutes)
- Total User Counter (Counts total amount of active people since the beginning)

PingFly __TODO:__
- Change Counter to match based on UUID, instead of IP (multiple people running under one IP/NAT).
- Make WebServer BackEnd Get Latest Program Version through PHP to avoid version file+human error.
- Add in a Percentage of Lost Packets (to see packet loss easyier).

# PingFly Updater (.exe)
## What this does
- PingFly Updater is embedded inside __PingFly.exe__.
- It is extracted when the user decides to update.
- It must be given the new files name for the original __PingFly.exe__ to be replaced.
- It then deletes the old PingFly.exe, and renames the downloaded (new) version with the original file name.
This prevents issues if the user decides to rename the program to somthing else other than "PingFly.exe".
- PingFly_Updater.exe then deletes itself. 

## Notes
- You don't need to touch it, it doesn't require updates or modifications and works with the original included copy.
- This program will not run without being specified a file name.
This prevents people from running it on their own (DoubleClick).

PingFly Updater __TODO:__
- Require admin permissions when running the updater, so that it can delete the old version of PingFly and rename the latest version of PingFly in its place.
