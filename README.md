# PingFly (.exe)
## What this does
PingFly measures the latency of up to 6 servers, with features such as:
- Averaging
- Packet Loss Counting
- 8 PreSet Location Based Server Lists (Choose the closest near you).
  - Perth
  - Adelaide
  - Sydney
  - Brisbane
  - San Francisco
  - Los Angeles
  - Paris
  - Singapore
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
