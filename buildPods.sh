#!/bin/bash

#original credit for the SwiftSupport and Getting the Developer Directory goes to @bq
#https://github.com/bq/ipa-packager

#To debug or troubleshoot, remove the >/dev/null or 2>/dev/null from the file

mkdir -p Pods

for XamarinPod in $(ls -d */); do
   echo "Processing ${XamarinPod}"
   for Sln in $(ls ${XamarinPod}Xamarin/*sln); do
      msbuild ${Sln} /t:Rebuild /p:Configuration=Release >/dev/null 2>/dev/null
      cp ${XamarinPod}Xamarin/bin/Release/*dll Pods/
   done
done

echo "Completed!"
