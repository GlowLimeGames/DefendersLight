//Maya ASCII 2016 scene
//Name: Zombe.0001.ma
//Last modified: Sat, Oct 15, 2016 06:56:05 PM
//Codeset: 1252
requires maya "2016";
requires "stereoCamera" "10.0";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2016";
fileInfo "version" "2016";
fileInfo "cutIdentifier" "201502261600-953408";
fileInfo "osv" "Microsoft Windows 8 Home Premium Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "student";
createNode transform -s -n "persp";
	rename -uid "7D6E6E33-4BA4-6349-D83A-D6BACC95CDCB";
	setAttr ".v" no;
	setAttr ".t" -type "double3" -3.5893626536220942 1.7988736841502284 1.1087667894259146 ;
	setAttr ".r" -type "double3" -18.938352714049294 -1872.9999999979059 0 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "4736119C-476D-91AE-2155-38926A725C8C";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999993;
	setAttr ".coi" 3.9681706723761589;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".tp" -type "double3" 0 0.51100136361356641 0.011388499188331874 ;
	setAttr ".hc" -type "string" "viewSet -p %camera";
createNode transform -s -n "top";
	rename -uid "EAA8D2C9-440E-6C18-7C36-18BC42C8F944";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 100.1 0 ;
	setAttr ".r" -type "double3" -89.999999999999986 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "CB416965-47EA-C79A-C75C-37833A4EDE27";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
createNode transform -s -n "front";
	rename -uid "77087853-425D-02FC-1BAB-E39B1F7A2ADC";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 0 100.1 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "183F75DF-47F7-F3C5-B48B-19B1CF8F2CB3";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
createNode transform -s -n "side";
	rename -uid "2E02891D-42FD-6B60-48BB-44A9965F6C3D";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 100.1 0 0 ;
	setAttr ".r" -type "double3" 0 89.999999999999986 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "6DF6634C-40E7-20CB-86B4-739FB056592B";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
createNode transform -n "pCylinder1";
	rename -uid "CC7E9AE4-4BD7-021A-5BF8-5EB8754E198B";
	setAttr ".t" -type "double3" 0 10.387161051524648 0 ;
createNode transform -n "transform1" -p "pCylinder1";
	rename -uid "B1A2A9FB-4C08-C3AD-5D5B-26A3E13C7F2D";
	setAttr ".v" no;
createNode mesh -n "pCylinderShape1" -p "transform1";
	rename -uid "2CD98E9C-4D53-A159-F3B8-CBB761D7B021";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.84375 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".dr" 1;
createNode transform -n "pSphere1";
	rename -uid "73974ADE-4AF2-49A0-B524-7EACC4BF24BB";
	setAttr ".t" -type "double3" 0 13.203828085723767 0.4208053330482141 ;
createNode transform -n "transform2" -p "pSphere1";
	rename -uid "7222FA9E-49E1-8EE8-0D39-B2AC2F65E443";
	setAttr ".v" no;
createNode mesh -n "pSphereShape1" -p "transform2";
	rename -uid "C7095F4E-4BE2-DFF1-EFC5-369435C47F25";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.125 0.5 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 41 ".pt";
	setAttr ".pt[0]" -type "float3" 0.014476761 -0.014524834 0.14044461 ;
	setAttr ".pt[1]" -type "float3" 0 -0.014524834 0.26953816 ;
	setAttr ".pt[2]" -type "float3" -0.014476761 -0.014524834 0.14044461 ;
	setAttr ".pt[3]" -type "float3" 0 0 0.14028035 ;
	setAttr ".pt[4]" -type "float3" 0 7.4505806e-009 0.12861277 ;
	setAttr ".pt[5]" -type "float3" 0 7.4505806e-009 0.084198311 ;
	setAttr ".pt[6]" -type "float3" 0 7.4505806e-009 0.12861277 ;
	setAttr ".pt[7]" -type "float3" 0 0 0.14028035 ;
	setAttr ".pt[8]" -type "float3" 0.050838761 0 -0.057237923 ;
	setAttr ".pt[9]" -type "float3" -0.050838761 0 -0.057237923 ;
	setAttr ".pt[10]" -type "float3" 0 0 -0.053127885 ;
	setAttr ".pt[11]" -type "float3" -0.045078345 0.058935493 -0.08184462 ;
	setAttr ".pt[12]" -type "float3" 0 -0.0085792886 -0.1230424 ;
	setAttr ".pt[13]" -type "float3" 0.045078345 0.058935493 -0.08184462 ;
	setAttr ".pt[14]" -type "float3" 0 0 -0.053127885 ;
	setAttr ".pt[15]" -type "float3" -0.13466807 -0.066416785 -0.23147832 ;
	setAttr ".pt[16]" -type "float3" 0 -0.0072599072 -0.14444554 ;
	setAttr ".pt[17]" -type "float3" 0.13466807 -0.066416785 -0.23147832 ;
	setAttr ".pt[18]" -type "float3" 0 0 -0.053127885 ;
	setAttr ".pt[19]" -type "float3" 0.0063974299 0 -0.13376181 ;
	setAttr ".pt[20]" -type "float3" 0 0 -0.14949286 ;
	setAttr ".pt[21]" -type "float3" -0.0063974271 0 -0.13376181 ;
	setAttr ".pt[22]" -type "float3" 0 0 -0.053127885 ;
	setAttr ".pt[23]" -type "float3" 0.027828591 -0.061051566 0.029411791 ;
	setAttr ".pt[25]" -type "float3" -0.027828591 -0.061051566 0.029411791 ;
	setAttr ".pt[26]" -type "float3" 0 0 -0.053127885 ;
	setAttr ".pt[27]" -type "float3" 0.020391189 0 -0.14281087 ;
	setAttr ".pt[28]" -type "float3" 0 -0.032786097 -0.16546927 ;
	setAttr ".pt[29]" -type "float3" -0.020391185 0 -0.1428109 ;
	setAttr ".pt[30]" -type "float3" 0 0 -0.053127885 ;
	setAttr ".pt[34]" -type "float3" 0 0 -0.053127885 ;
	setAttr ".pt[35]" -type "float3" -0.0018018307 0 -0.14033718 ;
	setAttr ".pt[36]" -type "float3" 0 0 -0.21383014 ;
	setAttr ".pt[37]" -type "float3" 0.0018018326 0 -0.14033718 ;
	setAttr ".pt[38]" -type "float3" 0 0 -0.053127885 ;
	setAttr ".pt[42]" -type "float3" -0.030870266 0 -0.045111641 ;
	setAttr ".pt[43]" -type "float3" -0.0020999918 0 -0.07157512 ;
	setAttr ".pt[44]" -type "float3" -1.4225957e-009 0 -0.089549802 ;
	setAttr ".pt[45]" -type "float3" 0.0020999922 0 -0.071575128 ;
	setAttr ".pt[46]" -type "float3" 0.030870266 0 -0.045111641 ;
	setAttr ".pt[55]" -type "float3" 0 0.046653084 0.14028035 ;
createNode transform -n "pCube1";
	rename -uid "CE1B2921-4BFB-4CB7-73D6-65A5485DB753";
	setAttr ".t" -type "double3" 0 3.6131058433424825 0 ;
	setAttr ".s" -type "double3" 1.4143203331720728 1.4143203331720728 1.4143203331720728 ;
createNode transform -n "transform3" -p "pCube1";
	rename -uid "8ADB9679-451E-075B-FB8D-C88D823CE185";
	setAttr ".v" no;
createNode mesh -n "pCubeShape1" -p "transform3";
	rename -uid "3EA930D9-4EAA-D35F-33FA-29AC4EED2D1B";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.375 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "pCube2";
	rename -uid "18240CFE-4504-75B7-33CE-819B6861AD02";
	setAttr ".t" -type "double3" -4.4408920985006262e-016 5.6827904132273037 0.33507094537830134 ;
	setAttr ".s" -type "double3" 0.85462695776761188 0.85462695776761188 0.85462695776761188 ;
createNode transform -n "transform4" -p "pCube2";
	rename -uid "AD907D1C-4CE6-955A-01BC-0DBCC47F4CBC";
	setAttr ".v" no;
createNode mesh -n "pCubeShape2" -p "transform4";
	rename -uid "9CFDC0F6-4638-85D1-6B26-ABAEDDDFBABA";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.21875 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 24 ".pt";
	setAttr ".pt[2]" -type "float3" 0.0043880069 0 0.028245155 ;
	setAttr ".pt[3]" -type "float3" -0.0043880069 0 0.028245155 ;
	setAttr ".pt[8]" -type "float3" -0.013531145 0 -0.043593232 ;
	setAttr ".pt[9]" -type "float3" 0 0 0.024229463 ;
	setAttr ".pt[18]" -type "float3" 0.01353112 0 -0.043593232 ;
	setAttr ".pt[26]" -type "float3" -0.010611454 0 -0.011035837 ;
	setAttr ".pt[29]" -type "float3" 0.010611454 0 -0.011035837 ;
	setAttr ".pt[31]" -type "float3" -0.019663647 0 -0.033863239 ;
	setAttr ".pt[32]" -type "float3" 0 0 0.024229463 ;
	setAttr ".pt[33]" -type "float3" 0.019663647 0 -0.033863239 ;
	setAttr ".pt[34]" -type "float3" 0 0 0.024229463 ;
	setAttr ".pt[50]" -type "float3" 0 0.02772443 -0.016058106 ;
	setAttr ".pt[52]" -type "float3" 0.022758186 0.040159419 0 ;
	setAttr ".pt[54]" -type "float3" -0.022758186 0.040159419 0 ;
	setAttr ".pt[63]" -type "float3" -0.021986773 0 -0.0092473086 ;
	setAttr ".pt[68]" -type "float3" 0.021986773 0 -0.0092473086 ;
	setAttr ".pt[74]" -type "float3" 0.01024553 0 -0.015270424 ;
	setAttr ".pt[75]" -type "float3" -0.01024553 0 -0.015270424 ;
	setAttr ".pt[82]" -type "float3" 0 -0.023104606 0 ;
	setAttr ".pt[83]" -type "float3" 0 -0.023104606 0 ;
	setAttr ".pt[84]" -type "float3" 0.021100594 0.0090678781 -1.3183898e-016 ;
	setAttr ".pt[85]" -type "float3" -0.021100594 0.0090678781 -1.3183898e-016 ;
	setAttr ".pt[91]" -type "float3" -0.023169234 0 -0.0092473086 ;
	setAttr ".pt[94]" -type "float3" 0.023169234 0 -0.0092473086 ;
createNode transform -n "pCube3";
	rename -uid "C66BB4B6-4562-FC3C-94D9-839ACAE41063";
	setAttr ".s" -type "double3" 0.085005840966941096 0.085005840966941096 0.085005840966941096 ;
createNode mesh -n "pCube3Shape" -p "pCube3";
	rename -uid "92BD5E85-4D55-46B8-055C-9F954C1AD3F6";
	setAttr -k off ".v";
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.15625 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 294 ".pt";
	setAttr ".pt[0]" -type "float3" 4.6566129e-010 0 4.6566129e-010 ;
	setAttr ".pt[1]" -type "float3" -4.6566129e-010 0 4.6566129e-010 ;
	setAttr ".pt[4]" -type "float3" 0 1.8626451e-009 0 ;
	setAttr ".pt[5]" -type "float3" 0 1.8626451e-009 0 ;
	setAttr ".pt[6]" -type "float3" 4.6566129e-010 -1.8626451e-009 0 ;
	setAttr ".pt[7]" -type "float3" -4.6566129e-010 -1.8626451e-009 0 ;
	setAttr ".pt[8]" -type "float3" -0.024550026 0.012482945 0.063071333 ;
	setAttr ".pt[9]" -type "float3" 0 0 2.3283064e-010 ;
	setAttr ".pt[12]" -type "float3" 0 1.8626451e-009 -1.8626451e-009 ;
	setAttr ".pt[13]" -type "float3" 0 2.3283064e-010 0 ;
	setAttr ".pt[14]" -type "float3" 9.3132257e-010 2.3283064e-010 0 ;
	setAttr ".pt[15]" -type "float3" 0 -1.8626451e-009 -9.3132257e-010 ;
	setAttr ".pt[16]" -type "float3" 0 -1.8626451e-009 -9.3132257e-010 ;
	setAttr ".pt[17]" -type "float3" 0 0 2.3283064e-010 ;
	setAttr ".pt[18]" -type "float3" 0.024550026 0.012482945 0.063071333 ;
	setAttr ".pt[19]" -type "float3" 0 0.019134153 0 ;
	setAttr ".pt[20]" -type "float3" 0 1.8626451e-009 -9.3132257e-010 ;
	setAttr ".pt[21]" -type "float3" 0 -9.3132257e-010 0 ;
	setAttr ".pt[22]" -type "float3" 0 -3.7252903e-009 9.3132257e-010 ;
	setAttr ".pt[23]" -type "float3" -9.3132257e-010 0 0 ;
	setAttr ".pt[24]" -type "float3" 9.3132257e-010 0 0 ;
	setAttr ".pt[26]" -type "float3" 1.1641532e-010 -0.00027555402 0 ;
	setAttr ".pt[27]" -type "float3" -2.910383e-011 0 0 ;
	setAttr ".pt[29]" -type "float3" -1.1641532e-010 -0.00027555402 0 ;
	setAttr ".pt[30]" -type "float3" 0 -0.00062597106 0 ;
	setAttr ".pt[31]" -type "float3" -0.024550026 -0.012482945 0.063071333 ;
	setAttr ".pt[32]" -type "float3" 0 1.8626451e-009 0 ;
	setAttr ".pt[33]" -type "float3" 0.024550026 -0.012482945 0.063071333 ;
	setAttr ".pt[34]" -type "float3" 0 1.8626451e-009 0 ;
	setAttr ".pt[35]" -type "float3" 0 0 -9.3132257e-010 ;
	setAttr ".pt[36]" -type "float3" 0 0 -9.3132257e-010 ;
	setAttr ".pt[39]" -type "float3" 0 0 1.8626451e-009 ;
	setAttr ".pt[40]" -type "float3" 0 9.3132257e-010 0 ;
	setAttr ".pt[41]" -type "float3" 0 9.3132257e-010 1.8626451e-009 ;
	setAttr ".pt[42]" -type "float3" 0 0 1.8626451e-009 ;
	setAttr ".pt[43]" -type "float3" 0 9.3132257e-010 1.8626451e-009 ;
	setAttr ".pt[45]" -type "float3" 4.6566129e-010 0 -1.8626451e-009 ;
	setAttr ".pt[46]" -type "float3" 5.8207661e-011 0 1.8626451e-009 ;
	setAttr ".pt[47]" -type "float3" -4.6566129e-010 0 -1.8626451e-009 ;
	setAttr ".pt[48]" -type "float3" -5.8207661e-011 0 1.8626451e-009 ;
	setAttr ".pt[51]" -type "float3" -4.6566129e-010 0 -9.3132257e-010 ;
	setAttr ".pt[52]" -type "float3" 9.3132257e-010 0 -9.3132257e-010 ;
	setAttr ".pt[53]" -type "float3" 4.6566129e-010 0 -9.3132257e-010 ;
	setAttr ".pt[54]" -type "float3" -9.3132257e-010 0 -9.3132257e-010 ;
	setAttr ".pt[55]" -type "float3" 2.910383e-011 0 0 ;
	setAttr ".pt[57]" -type "float3" 0 -1.8626451e-009 0 ;
	setAttr ".pt[58]" -type "float3" 0 -1.8626451e-009 0 ;
	setAttr ".pt[59]" -type "float3" 0 0.018923586 0 ;
	setAttr ".pt[60]" -type "float3" 0 0.018923586 0 ;
	setAttr ".pt[61]" -type "float3" 0 -9.3132257e-010 1.8626451e-009 ;
	setAttr ".pt[62]" -type "float3" 0 -9.3132257e-010 1.8626451e-009 ;
	setAttr ".pt[63]" -type "float3" 0 1.8626451e-009 0 ;
	setAttr ".pt[64]" -type "float3" 0 1.8626451e-009 0 ;
	setAttr ".pt[65]" -type "float3" 0 3.7252903e-009 0 ;
	setAttr ".pt[66]" -type "float3" 0 3.7252903e-009 0 ;
	setAttr ".pt[67]" -type "float3" 0 3.7252903e-009 0 ;
	setAttr ".pt[68]" -type "float3" 0 1.4901161e-008 9.3132257e-010 ;
	setAttr ".pt[69]" -type "float3" 0 1.4901161e-008 9.3132257e-010 ;
	setAttr ".pt[72]" -type "float3" 0 3.7252903e-009 0 ;
	setAttr ".pt[73]" -type "float3" 0 3.7252903e-009 0 ;
	setAttr ".pt[74]" -type "float3" 0 7.4505806e-009 0 ;
	setAttr ".pt[75]" -type "float3" 0 7.4505806e-009 0 ;
	setAttr ".pt[76]" -type "float3" 0 7.4505806e-009 9.3132257e-010 ;
	setAttr ".pt[77]" -type "float3" 0 3.7252903e-009 0 ;
	setAttr ".pt[78]" -type "float3" -1.8626451e-009 0 1.8626451e-009 ;
	setAttr ".pt[79]" -type "float3" 1.8626451e-009 0 1.8626451e-009 ;
	setAttr ".pt[86]" -type "float3" 0 0 4.6566129e-010 ;
	setAttr ".pt[87]" -type "float3" 0 7.4505806e-009 9.3132257e-010 ;
	setAttr ".pt[88]" -type "float3" 0 0 2.3283064e-010 ;
	setAttr ".pt[90]" -type "float3" 0 0 3.7252903e-009 ;
	setAttr ".pt[91]" -type "float3" 3.7252903e-009 0 1.8626451e-009 ;
	setAttr ".pt[92]" -type "float3" -3.7252903e-009 0 1.8626451e-009 ;
	setAttr ".pt[93]" -type "float3" 0 7.4505806e-009 0 ;
	setAttr ".pt[94]" -type "float3" 7.4505806e-009 0 1.8626451e-009 ;
	setAttr ".pt[95]" -type "float3" 0 0 -3.7252903e-009 ;
	setAttr ".pt[96]" -type "float3" 0 -3.7252903e-009 1.8626451e-009 ;
	setAttr ".pt[97]" -type "float3" 0 7.4505806e-009 0 ;
	setAttr ".pt[98]" -type "float3" -7.4505806e-009 0 0 ;
	setAttr ".pt[99]" -type "float3" 0 7.4505806e-009 0 ;
	setAttr ".pt[100]" -type "float3" -7.4505806e-009 0 1.8626451e-009 ;
	setAttr ".pt[101]" -type "float3" 7.4505806e-009 0 0 ;
	setAttr ".pt[102]" -type "float3" 0 -3.7252903e-009 1.8626451e-009 ;
	setAttr ".pt[103]" -type "float3" 0 7.4505806e-009 0 ;
	setAttr ".pt[104]" -type "float3" 0 0 -3.7252903e-009 ;
	setAttr ".pt[105]" -type "float3" 0 7.4505806e-009 0 ;
	setAttr ".pt[106]" -type "float3" 0 0 1.8626451e-009 ;
	setAttr ".pt[108]" -type "float3" -7.4505806e-009 0 1.8626451e-009 ;
	setAttr ".pt[109]" -type "float3" -7.4505806e-009 7.4505806e-009 0 ;
	setAttr ".pt[110]" -type "float3" -7.4505806e-009 0 0 ;
	setAttr ".pt[111]" -type "float3" 7.4505806e-009 7.4505806e-009 0 ;
	setAttr ".pt[112]" -type "float3" 0 0 1.8626451e-009 ;
	setAttr ".pt[113]" -type "float3" 7.4505806e-009 0 0 ;
	setAttr ".pt[114]" -type "float3" 7.4505806e-009 0 1.8626451e-009 ;
	setAttr ".pt[115]" -type "float3" 0 7.4505806e-009 0 ;
	setAttr ".pt[117]" -type "float3" 0 0 3.7252903e-009 ;
	setAttr ".pt[118]" -type "float3" -1.4901161e-008 0 1.8626451e-009 ;
	setAttr ".pt[119]" -type "float3" 1.4901161e-008 0 0 ;
	setAttr ".pt[120]" -type "float3" 0 0 1.8626451e-009 ;
	setAttr ".pt[124]" -type "float3" 1.4901161e-008 0 1.8626451e-009 ;
	setAttr ".pt[126]" -type "float3" 0 0 1.8626451e-009 ;
	setAttr ".pt[127]" -type "float3" 0 0 3.7252903e-009 ;
	setAttr ".pt[128]" -type "float3" -1.4901161e-008 0 0 ;
	setAttr ".pt[129]" -type "float3" 0 -7.4505806e-009 0 ;
	setAttr ".pt[130]" -type "float3" -1.4901161e-008 0 1.8626451e-009 ;
	setAttr ".pt[131]" -type "float3" 0 3.7252903e-009 0 ;
	setAttr ".pt[132]" -type "float3" 1.4901161e-008 0 0 ;
	setAttr ".pt[133]" -type "float3" 0 -7.4505806e-009 0 ;
	setAttr ".pt[134]" -type "float3" 0 3.7252903e-009 0 ;
	setAttr ".pt[135]" -type "float3" 0 -7.4505806e-009 0 ;
	setAttr ".pt[136]" -type "float3" 1.4901161e-008 0 1.8626451e-009 ;
	setAttr ".pt[137]" -type "float3" 0 3.7252903e-009 0 ;
	setAttr ".pt[138]" -type "float3" -1.4901161e-008 0 0 ;
	setAttr ".pt[139]" -type "float3" 0 -7.4505806e-009 0 ;
	setAttr ".pt[140]" -type "float3" 0 3.7252903e-009 0 ;
	setAttr ".pt[141]" -type "float3" -1.4901161e-008 -7.4505806e-009 0 ;
	setAttr ".pt[143]" -type "float3" 1.4901161e-008 0 0 ;
	setAttr ".pt[145]" -type "float3" 0 -7.4505806e-009 0 ;
	setAttr ".pt[147]" -type "float3" 0 -7.4505806e-009 0 ;
	setAttr ".pt[151]" -type "float3" 1.4901161e-008 -7.4505806e-009 0 ;
	setAttr ".pt[152]" -type "float3" -1.4901161e-008 0 0 ;
	setAttr ".pt[155]" -type "float3" 0 3.7252903e-009 0 ;
	setAttr ".pt[156]" -type "float3" 1.4901161e-008 3.7252903e-009 0 ;
	setAttr ".pt[157]" -type "float3" 1.4901161e-008 3.7252903e-009 0 ;
	setAttr ".pt[158]" -type "float3" 0 3.7252903e-009 0 ;
	setAttr ".pt[159]" -type "float3" -1.4901161e-008 -3.7252903e-009 0 ;
	setAttr ".pt[161]" -type "float3" 0 3.7252903e-009 0 ;
	setAttr ".pt[162]" -type "float3" -1.4901161e-008 3.7252903e-009 0 ;
	setAttr ".pt[164]" -type "float3" 1.4901161e-008 -3.7252903e-009 0 ;
	setAttr ".pt[167]" -type "float3" -1.4901161e-008 3.7252903e-009 0 ;
	setAttr ".pt[168]" -type "float3" 0 3.7252903e-009 0 ;
	setAttr ".pt[169]" -type "float3" 1.4901161e-008 0 -2.3283064e-010 ;
	setAttr ".pt[171]" -type "float3" -1.4901161e-008 0 0 ;
	setAttr ".pt[172]" -type "float3" 0 0 -4.6566129e-010 ;
	setAttr ".pt[173]" -type "float3" -1.4901161e-008 0 -2.3283064e-010 ;
	setAttr ".pt[175]" -type "float3" 0 0 -4.6566129e-010 ;
	setAttr ".pt[176]" -type "float3" 1.4901161e-008 0 0 ;
	setAttr ".pt[177]" -type "float3" 1.4901161e-008 0 0 ;
	setAttr ".pt[178]" -type "float3" 1.4901161e-008 0 0 ;
	setAttr ".pt[180]" -type "float3" 0 -7.4505806e-009 0 ;
	setAttr ".pt[181]" -type "float3" 1.4901161e-008 7.4505806e-009 0 ;
	setAttr ".pt[186]" -type "float3" -1.4901161e-008 7.4505806e-009 0 ;
	setAttr ".pt[189]" -type "float3" -1.4901161e-008 0 0 ;
	setAttr ".pt[190]" -type "float3" -1.4901161e-008 0 0 ;
	setAttr ".pt[191]" -type "float3" 0 -7.4505806e-009 0 ;
	setAttr ".pt[193]" -type "float3" -1.4901161e-008 0 0 ;
	setAttr ".pt[194]" -type "float3" -1.4901161e-008 0 0 ;
	setAttr ".pt[195]" -type "float3" 1.4901161e-008 0 0 ;
	setAttr ".pt[196]" -type "float3" 1.4901161e-008 0 0 ;
	setAttr ".pt[197]" -type "float3" 1.4901161e-008 0 0 ;
	setAttr ".pt[198]" -type "float3" 1.4901161e-008 0 0 ;
	setAttr ".pt[199]" -type "float3" -1.4901161e-008 0 0 ;
	setAttr ".pt[200]" -type "float3" -1.4901161e-008 0 0 ;
	setAttr ".pt[203]" -type "float3" -1.8626451e-009 -1.4901161e-008 0 ;
	setAttr ".pt[208]" -type "float3" 1.8626451e-009 -1.4901161e-008 0 ;
	setAttr ".pt[211]" -type "float3" 3.7252903e-009 0 1.8626451e-009 ;
	setAttr ".pt[212]" -type "float3" 0 3.7252903e-009 0 ;
	setAttr ".pt[214]" -type "float3" 0 0 1.8626451e-009 ;
	setAttr ".pt[216]" -type "float3" 0 3.7252903e-009 0 ;
	setAttr ".pt[217]" -type "float3" -3.7252903e-009 0 1.8626451e-009 ;
	setAttr ".pt[220]" -type "float3" 0 0 1.8626451e-009 ;
	setAttr ".pt[223]" -type "float3" -1.8626451e-009 -2.9802322e-008 0 ;
	setAttr ".pt[224]" -type "float3" 0 0 -1.8626451e-009 ;
	setAttr ".pt[228]" -type "float3" 1.8626451e-009 -2.9802322e-008 0 ;
	setAttr ".pt[229]" -type "float3" -1.8626451e-009 0 0 ;
	setAttr ".pt[230]" -type "float3" 0 2.9802322e-008 3.7252903e-009 ;
	setAttr ".pt[231]" -type "float3" 0 -2.9802322e-008 0 ;
	setAttr ".pt[232]" -type "float3" 0 0 -4.6566129e-010 ;
	setAttr ".pt[233]" -type "float3" 0 2.9802322e-008 3.7252903e-009 ;
	setAttr ".pt[234]" -type "float3" 1.8626451e-009 0 0 ;
	setAttr ".pt[235]" -type "float3" 0 0 4.6566129e-010 ;
	setAttr ".pt[236]" -type "float3" 0 -2.9802322e-008 0 ;
	setAttr ".pt[237]" -type "float3" -1.8626451e-009 0 0 ;
	setAttr ".pt[242]" -type "float3" 1.8626451e-009 0 -3.7252903e-009 ;
	setAttr ".pt[244]" -type "float3" 0 0 -5.8207661e-011 ;
	setAttr ".pt[245]" -type "float3" 0 -2.9802322e-008 0 ;
	setAttr ".pt[246]" -type "float3" 1.1641532e-010 0 0 ;
	setAttr ".pt[247]" -type "float3" -1.8626451e-009 2.9802322e-008 0 ;
	setAttr ".pt[248]" -type "float3" 1.1641532e-010 0 0 ;
	setAttr ".pt[249]" -type "float3" -1.1641532e-010 0 0 ;
	setAttr ".pt[250]" -type "float3" 0 -2.9802322e-008 0 ;
	setAttr ".pt[251]" -type "float3" -1.1641532e-010 0 0 ;
	setAttr ".pt[252]" -type "float3" 1.8626451e-009 2.9802322e-008 0 ;
	setAttr ".pt[255]" -type "float3" 1.4551915e-011 1.4901161e-008 0 ;
	setAttr ".pt[260]" -type "float3" -1.4551915e-011 1.4901161e-008 -3.7252903e-009 ;
	setAttr ".pt[262]" -type "float3" 0 0 3.7252903e-009 ;
	setAttr ".pt[263]" -type "float3" 0 0 -3.7252903e-009 ;
	setAttr ".pt[264]" -type "float3" 0 -1.4901161e-008 0 ;
	setAttr ".pt[265]" -type "float3" 0 0 9.3132257e-010 ;
	setAttr ".pt[266]" -type "float3" 0 -1.4901161e-008 0 ;
	setAttr ".pt[269]" -type "float3" 0 3.7252903e-009 1.8626451e-009 ;
	setAttr ".pt[270]" -type "float3" 0 -3.7252903e-009 0 ;
	setAttr ".pt[271]" -type "float3" 9.3132257e-010 0 0 ;
	setAttr ".pt[272]" -type "float3" 0 3.7252903e-009 1.8626451e-009 ;
	setAttr ".pt[273]" -type "float3" -9.3132257e-010 0 0 ;
	setAttr ".pt[274]" -type "float3" 0 -3.7252903e-009 0 ;
	setAttr ".pt[275]" -type "float3" 0 3.7252903e-009 0 ;
	setAttr ".pt[276]" -type "float3" 0 -3.7252903e-009 0 ;
	setAttr ".pt[277]" -type "float3" 0 1.8626451e-009 -3.7252903e-009 ;
	setAttr ".pt[278]" -type "float3" -2.3283064e-010 0 0 ;
	setAttr ".pt[279]" -type "float3" -2.3283064e-010 0 0 ;
	setAttr ".pt[280]" -type "float3" 0 3.7252903e-009 1.8626451e-009 ;
	setAttr ".pt[281]" -type "float3" 2.3283064e-010 0 0 ;
	setAttr ".pt[282]" -type "float3" 2.3283064e-010 0 0 ;
	setAttr ".pt[283]" -type "float3" 0 1.8626451e-009 -3.7252903e-009 ;
	setAttr ".pt[284]" -type "float3" 0 0 -3.7252903e-009 ;
	setAttr ".pt[285]" -type "float3" -0.0045273947 0.051169395 0.019796344 ;
	setAttr ".pt[286]" -type "float3" 0 0.077972874 0.0048189908 ;
	setAttr ".pt[287]" -type "float3" -0.004980301 -0.055739362 0.0078912266 ;
	setAttr ".pt[288]" -type "float3" 0 -0.066466361 -0.015213976 ;
	setAttr ".pt[289]" -type "float3" -0.03133494 0.044782575 0.091710001 ;
	setAttr ".pt[290]" -type "float3" -0.031271692 -0.056929804 0.088306598 ;
	setAttr ".pt[291]" -type "float3" 0.0045273979 0.051169395 0.019796344 ;
	setAttr ".pt[292]" -type "float3" 0.03133494 0.044782575 0.091710001 ;
	setAttr ".pt[293]" -type "float3" 0.0049803047 -0.055739362 0.0078912266 ;
	setAttr ".pt[294]" -type "float3" 0.031271692 -0.056929804 0.088306598 ;
createNode transform -n "camera1";
	rename -uid "5182968C-4171-3A11-8A9F-76BAD3E4E046";
	setAttr ".t" -type "double3" 0.66775731459684762 8.3516806677468427 22.6821245683672 ;
	setAttr -av ".tx";
	setAttr -av ".ty";
	setAttr -av ".tz";
	setAttr ".r" -type "double3" -20.400000000000453 -345.59999999995125 0 ;
	setAttr -av ".rx";
	setAttr -av ".ry";
	setAttr -av ".rz";
	setAttr ".rp" -type "double3" 0.074690097001796407 -3.6030648656726996 -17.439935999012405 ;
	setAttr ".rpt" -type "double3" 0 -1.7723973887664393 -0.21744618659034054 ;
	setAttr ".sp" -type "double3" 0.074690097001796407 -3.6030648656726996 -17.439935999012405 ;
createNode camera -n "cameraShape1" -p "camera1";
	rename -uid "2A3A22CB-4078-A584-B80C-0D937CFBD8C2";
	setAttr -k off ".v";
	setAttr ".rnd" no;
	setAttr ".cap" -type "double2" 1.41732 0.94488 ;
	setAttr ".ff" 0;
	setAttr ".coi" 21.528453272548688;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "camera1";
	setAttr ".den" -type "string" "camera1_depth";
	setAttr ".man" -type "string" "camera1_mask";
	setAttr ".tp" -type "double3" 0 5.5504698753356934 0.27862504497170448 ;
createNode lightLinker -s -n "lightLinker1";
	rename -uid "9E6BCC02-4471-889A-A958-DFAB50B81D4B";
	setAttr -s 2 ".lnk";
	setAttr -s 2 ".slnk";
createNode displayLayerManager -n "layerManager";
	rename -uid "201DECAA-4BD2-0A47-5A3D-3F8496614895";
createNode displayLayer -n "defaultLayer";
	rename -uid "F7576691-454A-47C8-A8DC-0FA2BEBF12CC";
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "F88BE6A8-481F-5098-B4A6-AE99DC6D4E82";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "EB17438F-430D-E0F2-37F7-AEBA87EB41EE";
	setAttr ".g" yes;
createNode polyCylinder -n "polyCylinder1";
	rename -uid "95A0B7AF-4B0D-29CC-035A-1DAF9F6C5CC7";
	setAttr ".sa" 8;
	setAttr ".sc" 1;
	setAttr ".cuv" 3;
createNode script -n "uiConfigurationScriptNode";
	rename -uid "5E777141-4839-F526-D526-1C9BE24E85A7";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"top\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"smoothShaded\" \n"
		+ "                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 0\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n"
		+ "                -rendererName \"vp2Renderer\" \n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n"
		+ "                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n                -width 1\n                -height 1\n                -sceneRenderFilter 0\n                $editorName;\n            modelEditor -e -viewSelected 0 $editorName;\n            modelEditor -e \n"
		+ "                -pluginObjects \"gpuCacheDisplayFilter\" 1 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n"
		+ "            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n"
		+ "            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n"
		+ "        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"side\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"smoothShaded\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 0\n                -backfaceCulling 0\n"
		+ "                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n                -rendererName \"vp2Renderer\" \n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n"
		+ "                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n"
		+ "                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n                -width 1\n                -height 1\n                -sceneRenderFilter 0\n                $editorName;\n            modelEditor -e -viewSelected 0 $editorName;\n            modelEditor -e \n                -pluginObjects \"gpuCacheDisplayFilter\" 1 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n"
		+ "            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n"
		+ "            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n"
		+ "            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels `;\n"
		+ "\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"front\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"smoothShaded\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 0\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n"
		+ "                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n                -rendererName \"vp2Renderer\" \n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n"
		+ "                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n"
		+ "                -width 1\n                -height 1\n                -sceneRenderFilter 0\n                $editorName;\n            modelEditor -e -viewSelected 0 $editorName;\n            modelEditor -e \n                -pluginObjects \"gpuCacheDisplayFilter\" 1 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"front\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n"
		+ "            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n"
		+ "            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n"
		+ "            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"persp\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"smoothShaded\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n"
		+ "                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 0\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n                -rendererName \"vp2Renderer\" \n                -objectFilterShowInHUD 1\n                -isFiltered 0\n"
		+ "                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n"
		+ "                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n                -width 941\n                -height 574\n                -sceneRenderFilter 0\n                $editorName;\n            modelEditor -e -viewSelected 0 $editorName;\n            modelEditor -e \n                -pluginObjects \"gpuCacheDisplayFilter\" 1 \n                $editorName;\n\t\t}\n\t} else {\n"
		+ "\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n"
		+ "            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n"
		+ "            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 941\n            -height 574\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n"
		+ "            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `outlinerPanel -unParent -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            outlinerEditor -e \n                -docTag \"isolOutln_fromSeln\" \n                -showShapes 0\n                -showReferenceNodes 0\n                -showReferenceMembers 1\n                -showAttributes 0\n                -showConnected 1\n                -showAnimCurvesOnly 0\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 1\n                -showAssets 1\n                -showContainedOnly 1\n                -showPublishedAsConnected 0\n                -showContainerContents 1\n                -ignoreDagHierarchy 0\n"
		+ "                -expandConnections 0\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 0\n                -highlightActive 1\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"defaultSetFilter\" \n                -showSetMembers 1\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n"
		+ "                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 0\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -docTag \"isolOutln_fromSeln\" \n            -showShapes 0\n            -showReferenceNodes 0\n            -showReferenceMembers 1\n            -showAttributes 0\n            -showConnected 1\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n"
		+ "            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n"
		+ "            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"graphEditor\" -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n"
		+ "                -showPublishedAsConnected 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n"
		+ "                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -stackedCurves 0\n                -stackedCurvesMin -1\n"
		+ "                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n"
		+ "                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n"
		+ "                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -stackedCurves 0\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n"
		+ "                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"dopeSheetPanel\" -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n"
		+ "                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n"
		+ "                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n"
		+ "                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n"
		+ "                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n"
		+ "                -ignoreOutlinerColor 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"clipEditorPanel\" -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels `;\n"
		+ "\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -manageSequencer 0 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n"
		+ "\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"sequenceEditorPanel\" -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -manageSequencer 1 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n"
		+ "                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -manageSequencer 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"hyperGraphPanel\" -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n"
		+ "                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n"
		+ "                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"visorPanel\" -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"createNodePanel\" -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"polyTexturePlacementPanel\" -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"renderWindowPanel\" -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"blendShapePanel\" (localizedPanelLabel(\"Blend Shape\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\tblendShapePanel -unParent -l (localizedPanelLabel(\"Blend Shape\")) -mbv $menusOkayInPanels ;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tblendShapePanel -edit -l (localizedPanelLabel(\"Blend Shape\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"dynRelEdPanel\" -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"relationshipPanel\" -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"referenceEditorPanel\" -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"componentEditorPanel\" (localizedPanelLabel(\"Component Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"componentEditorPanel\" -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"dynPaintScriptedPanelType\" -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"scriptEditorPanel\" -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"profilerPanel\" (localizedPanelLabel(\"Profiler Tool\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"profilerPanel\" -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"Stereo\" (localizedPanelLabel(\"Stereo\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"Stereo\" -l (localizedPanelLabel(\"Stereo\")) -mbv $menusOkayInPanels `;\nstring $editorName = ($panelName+\"Editor\");\n            stereoCameraView -e \n                -camera \"persp\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"smoothShaded\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 0\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n"
		+ "                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 4 4 \n                -bumpResolution 4 4 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 0\n                -occlusionCulling 0\n                -shadingModel 0\n"
		+ "                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n"
		+ "                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n                -width 0\n                -height 0\n                -sceneRenderFilter 0\n                -displayMode \"centerEye\" \n                -viewColor 0 0 0 1 \n                -useCustomBackground 1\n                $editorName;\n            stereoCameraView -e -viewSelected 0 $editorName;\n            stereoCameraView -e \n                -pluginObjects \"gpuCacheDisplayFilter\" 1 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Stereo\")) -mbv $menusOkayInPanels  $panelName;\nstring $editorName = ($panelName+\"Editor\");\n            stereoCameraView -e \n                -camera \"persp\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n"
		+ "                -displayAppearance \"smoothShaded\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 0\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n"
		+ "                -maxConstantTransparency 1\n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 4 4 \n                -bumpResolution 4 4 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 0\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n"
		+ "                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n                -width 0\n                -height 0\n                -sceneRenderFilter 0\n                -displayMode \"centerEye\" \n                -viewColor 0 0 0 1 \n                -useCustomBackground 1\n"
		+ "                $editorName;\n            stereoCameraView -e -viewSelected 0 $editorName;\n            stereoCameraView -e \n                -pluginObjects \"gpuCacheDisplayFilter\" 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"hyperShadePanel\" -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"nodeEditorPanel\" -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels `;\n"
		+ "\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -activeTab -1\n                -editorMode \"default\" \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -activeTab -1\n                -editorMode \"default\" \n"
		+ "                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-defaultImage \"vacantCell.xP:/\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"single\\\" -ps 1 100 100 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 941\\n    -height 574\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 941\\n    -height 574\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        setFocus `paneLayout -q -p1 $gMainPane`;\n        sceneUIReplacement -deleteRemaining;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 5 -size 12 -divisions 5 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	rename -uid "A57BF19C-41FC-2CC5-4126-B5B639EE6ED5";
	setAttr ".b" -type "string" "playbackOptions -min 1 -max 120 -ast 1 -aet 200 ";
	setAttr ".st" 6;
createNode polyTweak -n "polyTweak1";
	rename -uid "9564E3F7-4824-F863-8C61-B3B5784F0A84";
	setAttr ".uopa" yes;
	setAttr -s 18 ".tk[0:17]" -type "float3"  0.064703614 -0.054432716 0.12451476
		 0 -0.12010466 0.17609048 -0.064703614 -0.054432716 0.12451476 0.064703614 -0.054432716
		 0 -0.064703614 -0.054432716 -0.12451476 0 -0.12010466 -0.17609048 0.064703599 -0.054432716
		 -0.12451478 -0.064703673 -0.054432716 0 0 0.12010466 0.12451476 0 0.12010466 0.17609048
		 0 0.12010466 0.12451476 0 0.12010466 0 0 0.12010466 -0.12451476 0 0.12010466 -0.17609048
		 0 0.12010466 -0.12451478 0 0.12010466 0 0 -0.12010466 0 0 0.12010466 0;
createNode polySplit -n "polySplit1";
	rename -uid "A62E1368-461A-341E-C778-CBA06053F76B";
	setAttr -s 9 ".e[0:8]"  0.725743 0.725743 0.725743 0.725743 0.725743
		 0.725743 0.725743 0.725743 0.725743;
	setAttr -s 9 ".d[0:8]"  -2147483632 -2147483631 -2147483630 -2147483629 -2147483628 -2147483627 
		-2147483626 -2147483625 -2147483632;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyBevel3 -n "polyBevel1";
	rename -uid "6FB8FEC7-4C96-9DF6-2AFF-2DA8FEF4E594";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[25]" "e[29]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 10.387161051524648 0 1;
	setAttr ".ws" yes;
	setAttr ".oaf" yes;
	setAttr ".f" 0.099999999999999978;
	setAttr ".at" 180;
	setAttr ".fn" yes;
	setAttr ".mv" yes;
	setAttr ".mvt" 0.0001;
	setAttr ".sa" 30;
	setAttr ".ma" 180;
createNode polyTweak -n "polyTweak2";
	rename -uid "6DC6E249-4FE9-739C-088D-CA94907F4236";
	setAttr ".uopa" yes;
	setAttr -s 16 ".tk";
	setAttr ".tk[8]" -type "float3" 0.042601097 0 0.014987987 ;
	setAttr ".tk[9]" -type "float3" 0 0 0.030146491 ;
	setAttr ".tk[10]" -type "float3" -0.042601097 0 0.014987987 ;
	setAttr ".tk[11]" -type "float3" 0.11794537 0 0 ;
	setAttr ".tk[12]" -type "float3" -0.042601097 0 -0.014794556 ;
	setAttr ".tk[13]" -type "float3" 0 0 -0.069629788 ;
	setAttr ".tk[14]" -type "float3" 0.04260106 0 -0.014794575 ;
	setAttr ".tk[15]" -type "float3" -0.11794557 0 0 ;
	setAttr ".tk[18]" -type "float3" 0 -0.042766593 0 ;
	setAttr ".tk[19]" -type "float3" 0 -0.042766593 0 ;
	setAttr ".tk[20]" -type "float3" 0 -0.042766593 0 ;
	setAttr ".tk[21]" -type "float3" 0 -0.042766593 0 ;
	setAttr ".tk[22]" -type "float3" 0 -0.042766593 0 ;
	setAttr ".tk[23]" -type "float3" 0 -0.042766593 0 ;
	setAttr ".tk[24]" -type "float3" 0 -0.042766593 0 ;
	setAttr ".tk[25]" -type "float3" 0 -0.042766593 0 ;
createNode polyExtrudeFace -n "polyExtrudeFace1";
	rename -uid "BB155212-44C2-E0A9-96E2-A882E1D7C3CC";
	setAttr ".ics" -type "componentList" 1 "f[26:33]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 10.387161051524648 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 9.3026018 2.9802322e-008 ;
	setAttr ".rs" 38938;
	setAttr ".lt" -type "double3" 8.5689380042376948e-017 -2.8541622190680904e-017 0.13545843619374795 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.93529629707336426 9.272475039256582 -0.79978007078170776 ;
	setAttr ".cbx" -type "double3" 0.93529629707336426 9.3327281825671289 0.79978013038635254 ;
createNode polyTweak -n "polyTweak3";
	rename -uid "2885833C-4988-9AA4-9C0E-099A7D505C76";
	setAttr ".uopa" yes;
	setAttr -s 24 ".tk";
	setAttr ".tk[0]" -type "float3" 0 -2.9802322e-008 0 ;
	setAttr ".tk[1]" -type "float3" 0 -2.9802322e-008 0 ;
	setAttr ".tk[2]" -type "float3" 0 -2.9802322e-008 0 ;
	setAttr ".tk[3]" -type "float3" 0 -2.9802322e-008 0 ;
	setAttr ".tk[4]" -type "float3" 0 -2.9802322e-008 0 ;
	setAttr ".tk[5]" -type "float3" 0 -2.9802322e-008 0 ;
	setAttr ".tk[23]" -type "float3" 0 -2.9802322e-008 0 ;
	setAttr ".tk[25]" -type "float3" 0 -2.9802322e-008 0 ;
	setAttr ".tk[26]" -type "float3" 0 -2.9802322e-008 0 ;
	setAttr ".tk[27]" -type "float3" 0 -2.9802322e-008 0 ;
	setAttr ".tk[28]" -type "float3" 0 -2.9802322e-008 0 ;
	setAttr ".tk[30]" -type "float3" 0 -2.9802322e-008 0 ;
	setAttr ".tk[31]" -type "float3" 0.14882681 -1.8844194 0.24900097 ;
	setAttr ".tk[32]" -type "float3" 0 -1.8844194 0 ;
	setAttr ".tk[33]" -type "float3" 0 -1.8844194 0 ;
	setAttr ".tk[34]" -type "float3" 0.14882681 -1.8844194 -0.24900101 ;
	setAttr ".tk[35]" -type "float3" 0 -1.8844194 0 ;
	setAttr ".tk[36]" -type "float3" 0 -1.8844194 0 ;
	setAttr ".tk[37]" -type "float3" -0.14882681 -1.8844194 0.24900097 ;
	setAttr ".tk[38]" -type "float3" 0 -1.8844194 0 ;
	setAttr ".tk[39]" -type "float3" 0 -1.8844194 0 ;
	setAttr ".tk[40]" -type "float3" 0 -1.8844194 0 ;
	setAttr ".tk[41]" -type "float3" 0 -1.8844194 0 ;
	setAttr ".tk[42]" -type "float3" -0.14882681 -1.8844194 -0.24900103 ;
createNode deleteComponent -n "deleteComponent1";
	rename -uid "D22A1307-4EEB-26F0-1C1E-0CBBF06C5910";
	setAttr ".dc" -type "componentList" 6 "e[64]" "e[69]" "e[72]" "e[79]" "e[82]" "e[85]";
createNode polySplit -n "polySplit2";
	rename -uid "0B76E8BE-4366-32AF-13D3-FF8EB2A928C7";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483587 -2147483579;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit3";
	rename -uid "5792FCAC-4067-EAD1-52CA-209BC96BECDD";
	setAttr -s 2 ".e[0:1]"  0 1;
	setAttr -s 2 ".d[0:1]"  -2147483573 -2147483571;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyExtrudeFace -n "polyExtrudeFace2";
	rename -uid "0F900755-41D6-4D69-0FC8-B290818447EA";
	setAttr ".ics" -type "componentList" 2 "f[26:27]" "f[42:43]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 10.387161051524648 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 7.2831831 0.014064282 ;
	setAttr ".rs" 63572;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.94478237628936768 7.2831826560626123 -0.56995558738708496 ;
	setAttr ".cbx" -type "double3" 0.94478237628936768 7.2831831328997705 0.59808415174484253 ;
createNode polyTweak -n "polyTweak4";
	rename -uid "9E52F472-4B43-263F-F9BD-FC8A1C75E224";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[31:42]" -type "float3"  0 0.028944753 0.014064217
		 0 0.030092839 0.014064217 0 -0.030092839 0.014064217 0 0.028944753 0.014064217 0
		 -0.030092839 0.014064217 0 -0.030026097 0.014064217 0 0.028944753 0.014064217 0 -0.030092839
		 0.014064217 0 0.030092839 0.014064217 0 -0.030026097 0.014064217 0 -0.030092839 0.014064217
		 0 0.028944753 0.014064217;
createNode polyExtrudeFace -n "polyExtrudeFace3";
	rename -uid "C97EB37C-4D5F-18DE-820B-24843E863D87";
	setAttr ".ics" -type "componentList" 2 "f[26:27]" "f[42:43]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 10.387161051524648 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 7.0672007 0.014064282 ;
	setAttr ".rs" 55862;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.94478237628936768 7.0672004573474023 -0.56995558738708496 ;
	setAttr ".cbx" -type "double3" 0.94478237628936768 7.0672004573474023 0.59808415174484253 ;
createNode polyTweak -n "polyTweak5";
	rename -uid "86928892-47FF-A80B-8943-29B9485CCF2A";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[43:54]" -type "float3"  0 -0.21598256 0 0 -0.21598256
		 0 0 -0.21598256 0 0 -0.21598256 0 0 -0.21598256 0 0 -0.21598256 0 0 -0.21598256 0
		 0 -0.21598256 0 0 -0.21598256 0 0 -0.21598256 0 0 -0.21598256 0 0 -0.21598256 0;
createNode polyExtrudeFace -n "polyExtrudeFace4";
	rename -uid "EF8E52A8-4C9E-B540-EF5C-278927DAB423";
	setAttr ".ics" -type "componentList" 2 "f[26:27]" "f[42:43]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 10.387161051524648 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 6.8410158 0.014064282 ;
	setAttr ".rs" 43850;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.94478237628936768 6.8410156123766992 -0.56995558738708496 ;
	setAttr ".cbx" -type "double3" 0.94478237628936768 6.8410156123766992 0.59808415174484253 ;
createNode polyTweak -n "polyTweak6";
	rename -uid "EE5AE49D-436C-E594-C08C-9CB644EC080C";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[55:66]" -type "float3"  0 -0.22618483 0 0 -0.22618483
		 0 0 -0.22618483 0 0 -0.22618483 0 0 -0.22618483 0 0 -0.22618483 0 0 -0.22618483 0
		 0 -0.22618483 0 0 -0.22618483 0 0 -0.22618483 0 0 -0.22618483 0 0 -0.22618483 0;
createNode polyExtrudeFace -n "polyExtrudeFace5";
	rename -uid "51627AB2-4629-0FFF-A995-BEA05CFCC0F7";
	setAttr ".ics" -type "componentList" 2 "f[26:27]" "f[42:43]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 10.387161051524648 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 5.3596535 0.052545205 ;
	setAttr ".rs" 62512;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.88464808464050293 5.3596532695422265 -0.4068550169467926 ;
	setAttr ".cbx" -type "double3" 0.88464808464050293 5.3596532695422265 0.51194542646408081 ;
createNode polyTweak -n "polyTweak7";
	rename -uid "A77178E2-4248-BE8A-BE43-DFAEC8A5BE9E";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[67:78]" -type "float3"  -0.060134318 -1.48136222 0.038480945
		 0.060134314 -1.48136222 0.038480945 0.037310734 -1.48136222 0.16310057 -0.039225623
		 -1.48136222 0.15604897 0.037310734 -1.48136222 -0.086138666 -0.039225616 -1.48136222
		 -0.079087071 -0.037310749 -1.48136222 -0.086138703 -0.060134314 -1.48136222 0.038480889
		 0.039225623 -1.48136222 -0.079087026 0.060134318 -1.48136222 0.038480967 0.039225623
		 -1.48136222 0.15604897 -0.037310734 -1.48136222 0.16310057;
createNode polyTweak -n "polyTweak8";
	rename -uid "18659E24-4C64-97C8-E36C-E98752B49270";
	setAttr ".uopa" yes;
	setAttr -s 82 ".tk";
	setAttr ".tk[0]" -type "float3" 0 0 -0.10103682 ;
	setAttr ".tk[1]" -type "float3" 0 0 -0.10103682 ;
	setAttr ".tk[6]" -type "float3" 0 0 0.10073413 ;
	setAttr ".tk[8]" -type "float3" 0 0 0.10073413 ;
	setAttr ".tk[9]" -type "float3" 0 0.036285583 0 ;
	setAttr ".tk[10]" -type "float3" 0 0 -0.10073413 ;
	setAttr ".tk[12]" -type "float3" 0 0 -0.10073413 ;
	setAttr ".tk[13]" -type "float3" 0 0.036285583 0 ;
	setAttr ".tk[15]" -type "float3" 0 0 0.071725406 ;
	setAttr ".tk[17]" -type "float3" 0 0 0.071725406 ;
	setAttr ".tk[18]" -type "float3" 0 -0.1196657 0 ;
	setAttr ".tk[19]" -type "float3" 0 0 -0.071725406 ;
	setAttr ".tk[21]" -type "float3" 0 0 -0.071725421 ;
	setAttr ".tk[22]" -type "float3" 0 -0.1196657 0 ;
	setAttr ".tk[23]" -type "float3" -0.041640252 -0.057539959 -0.028442396 ;
	setAttr ".tk[24]" -type "float3" 0 0.08824604 0 ;
	setAttr ".tk[25]" -type "float3" 0.041640252 -0.057539959 -0.028442396 ;
	setAttr ".tk[26]" -type "float3" -0.0051202606 -0.048476152 0 ;
	setAttr ".tk[27]" -type "float3" 0.0051202606 -0.048476152 0 ;
	setAttr ".tk[28]" -type "float3" 0.025937723 -0.071198851 -0.040128354 ;
	setAttr ".tk[29]" -type "float3" 0 0.063054375 -0.052721113 ;
	setAttr ".tk[30]" -type "float3" -0.025937723 -0.071198851 -0.040128354 ;
	setAttr ".tk[31]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[32]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[33]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[34]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[35]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[36]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[37]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[38]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[39]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[40]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[41]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[42]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[43]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[44]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[45]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[46]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[47]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[48]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[49]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[50]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[51]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[52]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[53]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[54]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[55]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[56]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[57]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[58]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[59]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[60]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[61]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[62]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[63]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[64]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[65]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[66]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[67]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[68]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[69]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[70]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[71]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[72]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[73]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[74]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[75]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[76]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[77]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[78]" -type "float3" 0 0.620933 -0.0058645504 ;
	setAttr ".tk[79]" -type "float3" 0.0094118565 0.25874612 -0.0058645504 ;
	setAttr ".tk[80]" -type "float3" -0.0094118537 0.25874612 -0.0058645504 ;
	setAttr ".tk[81]" -type "float3" -0.0058396505 0.25874612 -0.017617274 ;
	setAttr ".tk[82]" -type "float3" 0.0061393538 0.25874612 -0.01695225 ;
	setAttr ".tk[83]" -type "float3" -0.0058396505 0.25874612 0.0058881892 ;
	setAttr ".tk[84]" -type "float3" 0.0061393525 0.25874612 0.0052231504 ;
	setAttr ".tk[85]" -type "float3" 0.0058396496 0.25874612 0.0058881892 ;
	setAttr ".tk[86]" -type "float3" 0.0094118537 0.25874612 -0.0058645504 ;
	setAttr ".tk[87]" -type "float3" -0.0061393538 0.25874612 0.0052231504 ;
	setAttr ".tk[88]" -type "float3" -0.0094118565 0.25874612 -0.0058645504 ;
	setAttr ".tk[89]" -type "float3" -0.0061393538 0.25874612 -0.01695225 ;
	setAttr ".tk[90]" -type "float3" 0.0058396505 0.25874612 -0.017617274 ;
createNode deleteComponent -n "deleteComponent2";
	rename -uid "0EE8A152-4620-A737-852A-3FA991ADBAD5";
	setAttr ".dc" -type "componentList" 4 "e[20]" "e[22]" "e[24]" "e[26]";
createNode polyExtrudeFace -n "polyExtrudeFace6";
	rename -uid "3F550899-477C-EBB6-1750-DBAE1A9CADDC";
	setAttr ".ics" -type "componentList" 2 "f[2:3]" "f[6:7]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 10.387161051524648 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 2.9802322e-008 11.609763 2.9802322e-008 ;
	setAttr ".rs" 47884;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.9822545051574707 11.17195585895873 -0.51086652278900146 ;
	setAttr ".cbx" -type "double3" 0.98225456476211548 12.047570859683523 0.51086658239364624 ;
createNode polyTweak -n "polyTweak9";
	rename -uid "926CA4F5-43D0-00D9-746B-A3917DAB6979";
	setAttr ".uopa" yes;
	setAttr -s 31 ".tk[0:30]" -type "float3"  0 0.090960488 0 0 0.090960488
		 0 0 0.090960488 0 0 0.090960488 0 0 0.090960488 0 0 0.090960488 0 0 0.50401938 0
		 0 0.50401938 0 0 0.50401938 0 0 0.50401938 0 0 0.50401938 0 0 0.50401938 0 0 0.50401938
		 0 0 0.50401938 0 0 0.50401938 0 0 0.42350444 0 0 0.42350444 0 0 0.42350444 0 0 0.42350444
		 0 0 0.42350444 0 0 0.42350444 0 0 0.42350444 0 0 0.42350444 0 0 0.090960488 0 0 0.090960488
		 0 0 0.090960488 0 0 0.090960488 0 0 0.090960488 0 0 0.090960488 0 0 0.090960488 0
		 0 0.090960488 0;
createNode polyExtrudeFace -n "polyExtrudeFace7";
	rename -uid "39B891BE-4F9D-3ABF-144D-4499A6AB35BC";
	setAttr ".ics" -type "componentList" 2 "f[2:3]" "f[6:7]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 10.387161051524648 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 11.609763 2.9802322e-008 ;
	setAttr ".rs" 40436;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -2.07893967628479 11.17195585895873 -0.51086652278900146 ;
	setAttr ".cbx" -type "double3" 2.07893967628479 12.047570978892812 0.51086658239364624 ;
createNode polyTweak -n "polyTweak10";
	rename -uid "306139D8-4DC2-29B4-E61E-7BA6494C089A";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[91:102]" -type "float3"  -1.35408497 0 0 -1.096685171
		 0 0 -1.19688404 0 0 -1.32922959 0 0 -1.35408497 0 0 -1.32922959 0 0 1.35408497 0
		 0 1.096685171 0 0 1.19688416 0 0 1.32922959 0 0 1.35408497 0 0 1.32922959 0 0;
createNode polyExtrudeFace -n "polyExtrudeFace8";
	rename -uid "C73CEBAE-409C-DF34-733B-F79226C5BB74";
	setAttr ".ics" -type "componentList" 2 "f[2:3]" "f[6:7]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 10.387161051524648 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 11.609763 2.9802322e-008 ;
	setAttr ".rs" 48022;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -2.1642580032348633 11.17195585895873 -0.51086652278900146 ;
	setAttr ".cbx" -type "double3" 2.1642580032348633 12.047570978892812 0.51086658239364624 ;
createNode polyTweak -n "polyTweak11";
	rename -uid "A83769A0-470B-DB58-6D12-E69E9E1C52C0";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[103:114]" -type "float3"  -0.085318275 0 0 -0.085318275
		 0 0 -0.085318275 0 0 -0.085318275 0 0 -0.085318275 0 0 -0.085318275 0 0 0.085318275
		 0 0 0.085318275 0 0 0.085318275 0 0 0.085318275 0 0 0.085318275 0 0 0.085318275 0
		 0;
createNode polyExtrudeFace -n "polyExtrudeFace9";
	rename -uid "59140283-411E-1069-FC0C-89AAFB742082";
	setAttr ".ics" -type "componentList" 2 "f[2:3]" "f[6:7]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 10.387161051524648 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 11.609763 2.9802322e-008 ;
	setAttr ".rs" 58604;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -2.2498404979705811 11.17195585895873 -0.51086652278900146 ;
	setAttr ".cbx" -type "double3" 2.2498404979705811 12.047570978892812 0.51086658239364624 ;
createNode polyTweak -n "polyTweak12";
	rename -uid "07AEF6CC-4E25-4E92-CA2E-C08BCD4150BF";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[115:126]" -type "float3"  -0.085582525 0 0 -0.085582525
		 0 0 -0.085582525 0 0 -0.085582525 0 0 -0.085582525 0 0 -0.085582525 0 0 0.085582525
		 0 0 0.085582525 0 0 0.085582525 0 0 0.085582525 0 0 0.085582525 0 0 0.085582525 0
		 0;
createNode polyExtrudeFace -n "polyExtrudeFace10";
	rename -uid "F2FF7213-428D-9309-A624-60BE317B7C3E";
	setAttr ".ics" -type "componentList" 2 "f[2:3]" "f[6:7]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 10.387161051524648 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 11.609763 2.9802322e-008 ;
	setAttr ".rs" 44554;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -3.3666043281555176 11.17195585895873 -0.51086652278900146 ;
	setAttr ".cbx" -type "double3" 3.3666043281555176 12.047570978892812 0.51086658239364624 ;
createNode polyTweak -n "polyTweak13";
	rename -uid "2E3519F5-43AB-E101-2C31-2A907DFCEC43";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[127:138]" -type "float3"  -1.11676383 0 0 -1.11676383
		 0 0 -1.11676383 0 0 -1.11676383 0 0 -1.11676383 0 0 -1.11676383 0 0 1.11676383 0
		 0 1.11676383 0 0 1.11676383 0 0 1.11676383 0 0 1.11676383 0 0 1.11676383 0 0;
createNode polyExtrudeFace -n "polyExtrudeFace11";
	rename -uid "49739A1B-49B3-E5DC-F96C-A8B03118F39A";
	setAttr ".ics" -type "componentList" 2 "f[2:3]" "f[6:7]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 10.387161051524648 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 11.595098 5.9604645e-008 ;
	setAttr ".rs" 34033;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -3.4267895221710205 11.138535832656393 -0.53275179862976074 ;
	setAttr ".cbx" -type "double3" 3.4267895221710205 12.051661884082327 0.53275191783905029 ;
createNode polyTweak -n "polyTweak14";
	rename -uid "32AD153A-40E9-4727-EBA7-6391488BB54D";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[139:150]" -type "float3"  -0.060185187 -0.028293602
		 -0.021885306 -0.060185309 -0.033420049 0 -0.06018525 0.0040909285 0 -0.060185205
		 0.0025364822 -0.020000506 -0.060185187 -0.028293602 0.021885306 -0.060185205 0.0025364822
		 0.020008795 0.060185187 -0.028293602 0.021885309 0.060185309 -0.033420049 0 0.06018525
		 0.0040909285 0 0.060185205 0.0025364822 0.020008795 0.060185187 -0.028293602 -0.021885306
		 0.060185205 0.0025364822 -0.020000506;
createNode polyExtrudeFace -n "polyExtrudeFace12";
	rename -uid "1DBC5244-4F26-0D1E-8EAD-77A6984D68EE";
	setAttr ".ics" -type "componentList" 2 "f[2:3]" "f[6:7]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 10.387161051524648 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 11.595099 5.9604645e-008 ;
	setAttr ".rs" 42738;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -3.7759897708892822 11.107288395656118 -0.5692141056060791 ;
	setAttr ".cbx" -type "double3" 3.7759897708892822 12.082910095942983 0.56921422481536865 ;
createNode polyTweak -n "polyTweak15";
	rename -uid "FFC9DA2D-4285-DDF7-C51A-2A8081385EC6";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[151:162]" -type "float3"  -0.34920016 -0.022706879 -0.036462303
		 -0.34920016 -0.03124783 0 -0.34920016 0.03124783 0 -0.34920016 0.028658014 -0.033322111
		 -0.34920016 -0.022706879 0.036462303 -0.34920016 0.028658014 0.033335913 0.34920016
		 -0.022706879 0.036462311 0.34920016 -0.03124783 0 0.34920016 0.03124783 0 0.34920016
		 0.028658014 0.033335913 0.34920016 -0.022706879 -0.036462303 0.34920016 0.028658014
		 -0.033322111;
createNode polyExtrudeFace -n "polyExtrudeFace13";
	rename -uid "EC186366-44E6-F8E0-3871-8ABF494B0178";
	setAttr ".ics" -type "componentList" 2 "f[2:3]" "f[6:7]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 10.387161051524648 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 11.595099 5.9604645e-008 ;
	setAttr ".rs" 54992;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -4.2817559242248535 11.107288157237539 -0.5692141056060791 ;
	setAttr ".cbx" -type "double3" 4.2817559242248535 12.082910334361562 0.56921422481536865 ;
createNode polyTweak -n "polyTweak16";
	rename -uid "D1888529-45EA-0FC6-0309-92BCF0885361";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[163:174]" -type "float3"  -0.50576603 0 0 -0.50576603
		 0 0 -0.50576603 0 0 -0.50576603 0 0 -0.50576603 0 0 -0.50576603 0 0 0.50576603 0
		 0 0.50576603 0 0 0.50576603 0 0 0.50576603 0 0 0.50576603 0 0 0.50576603 0 0;
createNode polyTweak -n "polyTweak17";
	rename -uid "BB9932AA-43B4-E13F-57E5-53AE1F2EC62B";
	setAttr ".uopa" yes;
	setAttr -s 40 ".tk";
	setAttr ".tk[0]" -type "float3" 0 -0.45809624 0 ;
	setAttr ".tk[1]" -type "float3" 0 -0.45809624 0 ;
	setAttr ".tk[2]" -type "float3" 0 -0.45809624 0 ;
	setAttr ".tk[3]" -type "float3" 0 -0.45809624 0 ;
	setAttr ".tk[4]" -type "float3" 0 -0.45809624 0 ;
	setAttr ".tk[5]" -type "float3" 0 -0.45809624 0 ;
	setAttr ".tk[19]" -type "float3" 0 0 0.040594194 ;
	setAttr ".tk[21]" -type "float3" 0 0 0.040594194 ;
	setAttr ".tk[23]" -type "float3" -0.075070113 -0.45809624 0.1035243 ;
	setAttr ".tk[24]" -type "float3" 0 -0.45809618 0.096090876 ;
	setAttr ".tk[25]" -type "float3" 0.075070113 -0.45809624 0.1035243 ;
	setAttr ".tk[26]" -type "float3" 0 -0.45809624 0 ;
	setAttr ".tk[27]" -type "float3" 0 -0.45809624 0 ;
	setAttr ".tk[28]" -type "float3" 0.048717748 -0.35638508 0 ;
	setAttr ".tk[29]" -type "float3" 0 -0.45809618 -0.083260879 ;
	setAttr ".tk[30]" -type "float3" -0.048717748 -0.35638508 0 ;
	setAttr ".tk[163]" -type "float3" -0.034552138 0 0 ;
	setAttr ".tk[164]" -type "float3" -0.034553606 0 0 ;
	setAttr ".tk[165]" -type "float3" -0.034552958 0 0 ;
	setAttr ".tk[166]" -type "float3" -0.034552459 0 0 ;
	setAttr ".tk[167]" -type "float3" -0.034552138 0 0 ;
	setAttr ".tk[168]" -type "float3" -0.034552459 0 0 ;
	setAttr ".tk[169]" -type "float3" 0.034552138 0 0 ;
	setAttr ".tk[170]" -type "float3" 0.034553606 0 0 ;
	setAttr ".tk[171]" -type "float3" 0.034552958 0 0 ;
	setAttr ".tk[172]" -type "float3" 0.034552459 0 0 ;
	setAttr ".tk[173]" -type "float3" 0.034552138 0 0 ;
	setAttr ".tk[174]" -type "float3" 0.034552459 0 0 ;
	setAttr ".tk[175]" -type "float3" -0.11765307 0.048316378 0.077585556 ;
	setAttr ".tk[176]" -type "float3" -0.11765389 0.066490076 0 ;
	setAttr ".tk[177]" -type "float3" -0.11765356 -0.066490076 0 ;
	setAttr ".tk[178]" -type "float3" -0.11765316 -0.060979337 0.070903741 ;
	setAttr ".tk[179]" -type "float3" -0.11765307 0.048316378 -0.077585556 ;
	setAttr ".tk[180]" -type "float3" -0.11765316 -0.060979337 -0.070933133 ;
	setAttr ".tk[181]" -type "float3" 0.11765307 0.048316378 -0.077585563 ;
	setAttr ".tk[182]" -type "float3" 0.11765389 0.066490076 0 ;
	setAttr ".tk[183]" -type "float3" 0.11765356 -0.066490076 0 ;
	setAttr ".tk[184]" -type "float3" 0.11765316 -0.060979337 -0.070933133 ;
	setAttr ".tk[185]" -type "float3" 0.11765307 0.048316378 0.077585556 ;
	setAttr ".tk[186]" -type "float3" 0.11765316 -0.060979337 0.070903741 ;
createNode polySplit -n "polySplit4";
	rename -uid "945A5ABC-4AA8-1A29-0809-1F8623F72266";
	setAttr -s 7 ".e[0:6]"  0.1 0.1 0.1 0.1 0.1 0.1 0.1;
	setAttr -s 7 ".d[0:6]"  -2147483473 -2147483472 -2147483466 -2147483464 -2147483470 -2147483469 
		-2147483473;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit5";
	rename -uid "4083DFBB-4211-90D5-D773-D5AA1EA54A1A";
	setAttr -s 7 ".e[0:6]"  0.1 0.1 0.1 0.1 0.1 0.1 0.1;
	setAttr -s 7 ".d[0:6]"  -2147483461 -2147483460 -2147483454 -2147483452 -2147483458 -2147483457 
		-2147483461;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyTweak -n "polyTweak18";
	rename -uid "2ACD0055-439B-B1A7-A7FC-0F84CA5B34D7";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[187:198]" -type "float3"  -0.06708312 0 0 0.067083165
		 0 0 -0.06708312 0 0 -0.054127544 0 0 0.014855688 0 0 -0.054127544 0 0 0.067083105
		 0 0 -0.067083165 0 0 0.06708312 0 0 0.054127544 0 0 -0.014855688 0 0 0.054127544
		 0 0;
createNode polySplit -n "polySplit6";
	rename -uid "804048C5-4932-66C4-1442-E6BDCC841E4D";
	setAttr -s 5 ".e[0:4]"  0.1 0.1 0.1 0.89999998 0.89999998;
	setAttr -s 5 ".d[0:4]"  -2147483614 -2147483638 -2147483627 -2147483641 -2147483617;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit7";
	rename -uid "C53FEB0A-4146-8DA3-370C-A180F77D5A37";
	setAttr -s 5 ".e[0:4]"  0.89999998 0.89999998 0.1 0.1 0.1;
	setAttr -s 5 ".d[0:4]"  -2147483613 -2147483637 -2147483625 -2147483642 -2147483618;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit8";
	rename -uid "4335EE93-42B0-2D3A-0FAC-829FE7D06828";
	setAttr -s 5 ".e[0:4]"  0 0.92141801 0.91122198 0.91789299 0;
	setAttr -s 5 ".d[0:4]"  -2147483255 -2147483631 -2147483632 -2147483633 -2147483251;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit9";
	rename -uid "65A31EDD-4BF3-787A-622F-25B21ACB2DEC";
	setAttr -s 5 ".e[0:4]"  0 0.96232897 0.91626698 0.94833797 0;
	setAttr -s 5 ".d[0:4]"  -2147483242 -2147483634 -2147483629 -2147483630 -2147483246;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySphere -n "polySphere1";
	rename -uid "0878CBD3-431B-15A1-1320-0AA170B64CA1";
	setAttr ".sa" 8;
	setAttr ".sh" 8;
createNode deleteComponent -n "deleteComponent3";
	rename -uid "A882196D-40A0-A19C-C1CC-E7AEDC3C6421";
	setAttr ".dc" -type "componentList" 2 "f[0:1]" "f[8:9]";
createNode polyExtrudeFace -n "polyExtrudeFace14";
	rename -uid "A3CC163D-4A97-D4AA-DD5C-D587F210AAAF";
	setAttr ".ics" -type "componentList" 2 "f[10:11]" "f[197:198]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 10.387161051524648 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -2.9802322e-008 12.030028 -0.019741625 ;
	setAttr ".rs" 53867;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.7387237548828125 12.011285578502187 -0.7937629222869873 ;
	setAttr ".cbx" -type "double3" 0.73872369527816772 12.048771654857168 0.75427967309951782 ;
createNode polyTweak -n "polyTweak19";
	rename -uid "5C28F20D-4832-EB1D-3C90-67BF7894CD48";
	setAttr ".uopa" yes;
	setAttr -s 16 ".tk";
	setAttr ".tk[17]" -type "float3" -0.0026569273 0.0032690391 0 ;
	setAttr ".tk[199]" -type "float3" 0.016546495 -0.010243617 0 ;
	setAttr ".tk[200]" -type "float3" 0.020129811 0.00047865187 0 ;
	setAttr ".tk[201]" -type "float3" 0.055125311 0.0048293173 3.469447e-018 ;
	setAttr ".tk[202]" -type "float3" 0.020129818 0.00047865187 0 ;
	setAttr ".tk[203]" -type "float3" -0.023028994 0.00059780292 0 ;
	setAttr ".tk[204]" -type "float3" -0.016546506 -0.010243613 0 ;
	setAttr ".tk[205]" -type "float3" -0.020129818 0.00047865187 0 ;
	setAttr ".tk[206]" -type "float3" -0.055125289 0.0048293136 0 ;
	setAttr ".tk[207]" -type "float3" -0.020129811 0.00047865187 0 ;
	setAttr ".tk[208]" -type "float3" 0.023028994 0.00059780292 0 ;
	setAttr ".tk[209]" -type "float3" -0.010973215 0.003644377 0 ;
	setAttr ".tk[210]" -type "float3" 0.052054115 0.013022463 3.469447e-018 ;
	setAttr ".tk[212]" -type "float3" 0.0066436185 0.0034489725 0 ;
	setAttr ".tk[213]" -type "float3" -0.052689724 0.013016635 0 ;
	setAttr ".tk[214]" -type "float3" 0.0081242546 0.0035157967 0 ;
createNode polyExtrudeFace -n "polyExtrudeFace15";
	rename -uid "305267AD-405D-DFF5-0F97-18819B1D990E";
	setAttr ".ics" -type "componentList" 2 "f[10:11]" "f[197:198]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 10.387161051524648 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -2.9802322e-008 12.171577 -0.062282413 ;
	setAttr ".rs" 35277;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.57283717393875122 12.157043015254507 -0.66249096393585205 ;
	setAttr ".cbx" -type "double3" 0.57283711433410645 12.186111127627859 0.53792613744735718 ;
createNode polyTweak -n "polyTweak20";
	rename -uid "85559B9A-4AD3-380B-20C8-73BA20444773";
	setAttr ".uopa" yes;
	setAttr -s 9 ".tk[214:222]" -type "float3"  -6.6923529e-009 0.14575739
		 -0.21635355 -6.6923529e-009 0.14575739 -0.046973929 -0.14699757 0.14564995 -0.15830642
		 -0.16588657 0.13733949 -0.046973929 -0.14699757 0.14564995 0.065206125 -6.6923529e-009
		 0.14575739 0.13127197 0.16588657 0.13733949 -0.046973929 0.14699756 0.14564995 -0.15830642
		 0.14699756 0.14564995 0.065206125;
createNode polyTweak -n "polyTweak21";
	rename -uid "CE1EFB64-4C28-DEAE-E678-169A9D645A24";
	setAttr ".uopa" yes;
	setAttr -s 17 ".tk";
	setAttr ".tk[10]" -type "float3" 0.05418003 0 -3.9252307e-017 ;
	setAttr ".tk[11]" -type "float3" 0 0 0.074264899 ;
	setAttr ".tk[12]" -type "float3" 0 0 0.003103131 ;
	setAttr ".tk[13]" -type "float3" 0 0 0.074264884 ;
	setAttr ".tk[14]" -type "float3" -0.054180026 0 -3.9252307e-017 ;
	setAttr ".tk[18]" -type "float3" 0.07078962 0 -2.1243199e-017 ;
	setAttr ".tk[19]" -type "float3" 0 0 0.021597475 ;
	setAttr ".tk[20]" -type "float3" 0 0 -0.071379833 ;
	setAttr ".tk[21]" -type "float3" 0 0 0.021597438 ;
	setAttr ".tk[22]" -type "float3" -0.07078962 0 -2.1243199e-017 ;
	setAttr ".tk[26]" -type "float3" 0.076622136 0 0 ;
	setAttr ".tk[28]" -type "float3" 0 0 -0.062645987 ;
	setAttr ".tk[30]" -type "float3" -0.076622136 0 0 ;
	setAttr ".tk[34]" -type "float3" 0.082564592 0 3.7175594e-017 ;
	setAttr ".tk[38]" -type "float3" -0.082564592 0 3.7175594e-017 ;
	setAttr ".tk[42]" -type "float3" 0.06039761 0 6.3784996e-017 ;
	setAttr ".tk[46]" -type "float3" -0.06039761 0 6.3784996e-017 ;
createNode deleteComponent -n "deleteComponent4";
	rename -uid "5C421DDD-4AF8-E0BE-19BD-818A3BD36E55";
	setAttr ".dc" -type "componentList" 4 "e[108]" "e[110]" "e[112]" "e[114]";
createNode deleteComponent -n "deleteComponent5";
	rename -uid "F7A9F68B-4313-F83B-F4ED-BAB56CC26286";
	setAttr ".dc" -type "componentList" 4 "e[100]" "e[102]" "e[104]" "e[106]";
createNode polyTweak -n "polyTweak22";
	rename -uid "D38A8E46-4361-8D19-5033-E28E929CF07D";
	setAttr ".uopa" yes;
	setAttr -s 9 ".tk[222:230]" -type "float3"  0 0.080135159 -0.18821093
		 -4.7730282e-009 0.21268819 -0.049059108 -0.10402185 0.12519068 -0.14052309 -0.11738861
		 0.18362036 -0.049059048 -0.10402182 0.30010688 0.043101098 -1.1175871e-008 0.35217965
		 0.097376689 0.11738861 0.18362036 -0.049059052 0.10402185 0.12519066 -0.14052306
		 0.10402182 0.30010682 0.043101083;
createNode deleteComponent -n "deleteComponent6";
	rename -uid "0989E787-4127-EFAD-57F4-5D8DD9FA83CB";
	setAttr ".dc" -type "componentList" 2 "f[10:11]" "f[197:198]";
createNode groupId -n "groupId1";
	rename -uid "5C557BF9-4B98-55BA-DDC1-98A674E81A99";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts1";
	rename -uid "7F28406F-4806-98AB-F713-A4A1A01037C6";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "f[0:51]";
createNode groupId -n "groupId2";
	rename -uid "4F6D96D0-4F95-13F0-C3CB-C1868A1402E4";
	setAttr ".ihi" 0;
createNode groupId -n "groupId3";
	rename -uid "A7BB2555-4EDE-5758-7CA9-B6BA55C3DCBA";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts2";
	rename -uid "70FA700C-4CD8-D4AC-6BE9-E79BB44BE298";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "f[0:223]";
createNode groupId -n "groupId4";
	rename -uid "EC5592F2-4220-5A10-0851-F19BED5D80A5";
	setAttr ".ihi" 0;
createNode polyCube -n "polyCube1";
	rename -uid "92186B5C-4DD6-E7F7-96B5-F188014E17DF";
	setAttr ".cuv" 4;
createNode polySmoothFace -n "polySmoothFace1";
	rename -uid "939174BC-4EF2-97B0-4B4C-65927D1B997E";
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".sdt" 2;
	setAttr ".suv" yes;
	setAttr ".ps" 0.10000000149011612;
	setAttr ".ro" 1;
	setAttr ".ma" yes;
	setAttr ".m08" yes;
createNode polyTweak -n "polyTweak50";
	rename -uid "CC03A987-44B6-96AD-65DE-62B1C411E97E";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk[0:7]" -type "float3"  -0.34532741 -0.34532741 0
		 0.34532741 -0.34532741 0 -0.34532741 0.34532741 0 0.34532741 0.34532741 0 -0.34532741
		 0.34532741 0 0.34532741 0.34532741 0 -0.34532741 -0.34532741 0 0.34532741 -0.34532741
		 0;
createNode polyExtrudeFace -n "polyExtrudeFace33";
	rename -uid "B5AD50AF-4190-50E4-D0D9-18A7F4FF9C59";
	setAttr ".ics" -type "componentList" 2 "f[18:19]" "f[22:23]";
	setAttr ".ix" -type "matrix" 1.4143203331720728 0 0 0 0 1.4143203331720728 0 0 0 0 1.4143203331720728 0
		 0 8.1516316382320664 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 9.1662931 0 ;
	setAttr ".rs" 49774;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.74445333339694597 8.906377418983686 -0.4043503851652247 ;
	setAttr ".cbx" -type "double3" 0.74445333339694597 9.4262084345898867 0.4043503851652247 ;
createNode polyTweak -n "polyTweak51";
	rename -uid "87144BFD-4CCC-645D-C318-EA959D76BF2D";
	setAttr ".uopa" yes;
	setAttr -s 26 ".tk[0:25]" -type "float3"  0.025122756 0.12195873 -0.041031279
		 -0.025122756 0.12195873 -0.041031279 0.0029183477 0.39338619 -1.4901161e-008 -0.0029183477
		 0.39338619 -1.4901161e-008 0.02596502 0.39338619 -1.4901161e-008 -0.02596502 0.39338619
		 -1.4901161e-008 0.0999557 0.12195873 0.041031279 -0.0999557 0.12195873 0.041031279
		 -0.15126987 0.59298873 -0.0891027 0 0.26719832 0 0.1403688 0.26719832 0 -0.1403688
		 0.26719832 0 0 0.26719832 0.025617654 0.17631988 0.59298873 0.0891027 -0.17631988
		 0.59298873 0.0891027 0 0.052685067 0.055392221 0.10208632 0.052685067 0 -0.10208632
		 0.052685067 0 0 0.052685067 -0.055392221 0.15126987 0.59298873 -0.0891027 0 0.22447413
		 -0.085170619 0 0.13380395 0 0 0.4167141 0.11564796 0 -0.036380995 0 -0.31895909 0.53364557
		 0 0.31895909 0.53364557 0;
createNode polyExtrudeFace -n "polyExtrudeFace34";
	rename -uid "DA87CBB4-49A5-E715-99F6-F0BAE64217DA";
	setAttr ".ics" -type "componentList" 2 "f[18:19]" "f[22:23]";
	setAttr ".ix" -type "matrix" 1.4143203331720728 0 0 0 0 1.4143203331720728 0 0 0 0 1.4143203331720728 0
		 0 8.1516316382320664 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 9.1662931 0 ;
	setAttr ".rs" 62169;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -1.3775677826527239 8.9063768288832588 -0.26761381045387123 ;
	setAttr ".cbx" -type "double3" 1.3775677826527239 9.4262087717901295 0.26761381045387123 ;
createNode polyTweak -n "polyTweak52";
	rename -uid "E6F59B40-4EE7-9052-0EE8-23954AD39310";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[26:37]" -type "float3"  0.50986159 0 0.09668009 0.44764566
		 0 0 0.5225547 0 0.09393438 0.47730026 0 0 0.48717341 0 -0.09668009 0.50168091 0 -0.09393438
		 -0.48717341 0 -0.09668009 -0.44764566 0 0 -0.50168091 0 -0.09393438 -0.47730026 0
		 0 -0.50986159 0 0.09668009 -0.5225547 0 0.09393438;
createNode polyExtrudeFace -n "polyExtrudeFace35";
	rename -uid "A3122E5F-43CF-10DD-BDE1-3FA93F173582";
	setAttr ".ics" -type "componentList" 2 "f[18:19]" "f[22:23]";
	setAttr ".ix" -type "matrix" 1.4143203331720728 0 0 0 0 1.4143203331720728 0 0 0 0 1.4143203331720728 0
		 0 8.1516316382320664 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 9.1662931 0 ;
	setAttr ".rs" 51324;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -2.1357270414766765 8.9244556513774924 -0.24899953504681668 ;
	setAttr ".cbx" -type "double3" 2.1357270414766765 9.4081299492958959 0.24899953504681668 ;
createNode polyTweak -n "polyTweak53";
	rename -uid "650BF809-42F8-9162-D281-BBAC2DBADB61";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[38:49]" -type "float3"  0.53650957 0.0086549642 0.013161298
		 0.53605908 0.012782714 0 0.53660136 -0.010126926 0.012787515 0.53627378 -0.012782714
		 0 0.5363453 0.0086549642 -0.013161298 0.53645045 -0.010126926 -0.012787515 -0.5363453
		 0.0086549642 -0.013161298 -0.53605908 0.012782714 0 -0.53645045 -0.010126926 -0.012787515
		 -0.53627378 -0.012782714 0 -0.53650957 0.0086549642 0.013161298 -0.53660136 -0.010126926
		 0.012787515;
createNode polyExtrudeFace -n "polyExtrudeFace36";
	rename -uid "6431E1D7-4056-ABF2-0CEF-F7A3B1283B37";
	setAttr ".ics" -type "componentList" 2 "f[18:19]" "f[22:23]";
	setAttr ".ix" -type "matrix" 1.4143203331720728 0 0 0 0 1.4143203331720728 0 0 0 0 1.4143203331720728 0
		 0 8.1516316382320664 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 9.1662931 0 ;
	setAttr ".rs" 53036;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -2.8267142413488635 8.9020479364479037 -0.27207071253194193 ;
	setAttr ".cbx" -type "double3" 2.8267142413488635 9.4305376642254846 0.27207071253194193 ;
createNode polyTweak -n "polyTweak54";
	rename -uid "132AD5D6-4BE5-0077-ECE2-42B927FC8D5B";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[50:61]" -type "float3"  0.48800647 -0.010727292 -0.01631256
		 0.48856479 -0.015843345 0 0.48789245 0.012551641 -0.015849279 0.48829865 0.015843345
		 0 0.48821002 -0.010727292 0.01631256 0.48807979 0.012551641 0.015849279 -0.48821002
		 -0.010727292 0.01631256 -0.48856479 -0.015843345 0 -0.48807979 0.012551641 0.015849279
		 -0.48829865 0.015843345 0 -0.48800647 -0.010727292 -0.01631256 -0.48789245 0.012551641
		 -0.015849279;
createNode polyExtrudeFace -n "polyExtrudeFace37";
	rename -uid "82823A66-4A9D-3FA8-0FAA-E1B14A720973";
	setAttr ".ics" -type "componentList" 2 "f[18:19]" "f[22:23]";
	setAttr ".ix" -type "matrix" 1.4143203331720728 0 0 0 0 1.4143203331720728 0 0 0 0 1.4143203331720728 0
		 0 8.1516316382320664 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 9.2313643 0 ;
	setAttr ".rs" 42219;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -3.0192697432140707 9.0800146383466505 -0.27207071253194193 ;
	setAttr ".cbx" -type "double3" 3.0192697432140707 9.3827132279869279 0.27207071253194193 ;
createNode polyTweak -n "polyTweak55";
	rename -uid "6D8BE692-45E0-6C2A-3806-2CB6A5A658A3";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[62:73]" -type "float3"  0.13614693 0.10005575 0 0.13614693
		 0.12583156 0 0.13614693 -0.017229583 0 0.13614693 -0.033814028 0 0.13614693 0.10005575
		 0 0.13614693 -0.017229583 0 -0.13614693 0.10005575 0 -0.13614693 0.12583156 0 -0.13614693
		 -0.017229583 0 -0.13614693 -0.033814028 0 -0.13614693 0.10005575 0 -0.13614693 -0.017229583
		 0;
createNode polyExtrudeFace -n "polyExtrudeFace38";
	rename -uid "C40428D0-4959-5BFF-0F49-DCAD4FBE863C";
	setAttr ".ics" -type "componentList" 4 "f[18:19]" "f[22:23]" "f[77]" "f[79]";
	setAttr ".ix" -type "matrix" 1.4143203331720728 0 0 0 0 1.4143203331720728 0 0 0 0 1.4143203331720728 0
		 0 8.1516316382320664 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 9.2313633 1.6860012e-007 ;
	setAttr ".rs" 51652;
	setAttr ".lt" -type "double3" -7.8843181983145882e-016 -1.6354105569771349e-015 
		0.18108811988622481 ;
	setAttr ".kft" no;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -3.3762956758028686 9.0800140482462233 -0.27207054393181979 ;
	setAttr ".cbx" -type "double3" 3.3762956758028686 9.3827133122869881 0.27207088113206401 ;
createNode polyTweak -n "polyTweak56";
	rename -uid "E83A711E-4584-7634-8068-92B25B4D5102";
	setAttr ".uopa" yes;
	setAttr -s 20 ".tk";
	setAttr ".tk[64]" -type "float3" -1.1920929e-007 0 1.1920929e-007 ;
	setAttr ".tk[65]" -type "float3" -1.1920929e-007 0 1.1920929e-007 ;
	setAttr ".tk[66]" -type "float3" -1.1920929e-007 0 1.1920929e-007 ;
	setAttr ".tk[67]" -type "float3" -1.1920929e-007 0 1.1920929e-007 ;
	setAttr ".tk[68]" -type "float3" 1.1920929e-007 0 1.1920929e-007 ;
	setAttr ".tk[70]" -type "float3" 1.1920929e-007 0 1.1920929e-007 ;
	setAttr ".tk[71]" -type "float3" 1.1920929e-007 0 1.1920929e-007 ;
	setAttr ".tk[73]" -type "float3" 1.1920929e-007 0 1.1920929e-007 ;
	setAttr ".tk[74]" -type "float3" 0.25243652 0 1.1920929e-007 ;
	setAttr ".tk[75]" -type "float3" 0.25243652 0 1.1920929e-007 ;
	setAttr ".tk[76]" -type "float3" 0.25243652 0 1.1920929e-007 ;
	setAttr ".tk[77]" -type "float3" 0.25243652 0 1.1920929e-007 ;
	setAttr ".tk[78]" -type "float3" 0.25243652 0 1.1920929e-007 ;
	setAttr ".tk[79]" -type "float3" 0.25243652 0 1.1920929e-007 ;
	setAttr ".tk[80]" -type "float3" -0.25243652 0 1.1920929e-007 ;
	setAttr ".tk[81]" -type "float3" -0.25243652 0 1.1920929e-007 ;
	setAttr ".tk[82]" -type "float3" -0.25243652 0 1.1920929e-007 ;
	setAttr ".tk[83]" -type "float3" -0.25243652 0 1.1920929e-007 ;
	setAttr ".tk[84]" -type "float3" -0.25243652 0 1.1920929e-007 ;
	setAttr ".tk[85]" -type "float3" -0.25243652 0 1.1920929e-007 ;
createNode polyExtrudeFace -n "polyExtrudeFace39";
	rename -uid "5EE155F0-40AC-A104-EDD0-698C391E5491";
	setAttr ".ics" -type "componentList" 2 "f[18:19]" "f[22:23]";
	setAttr ".ix" -type "matrix" 1.4143203331720728 0 0 0 0 1.4143203331720728 0 0 0 0 1.4143203331720728 0
		 0 8.1516316382320664 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 9.3619986 0.0066469754 ;
	setAttr ".rs" 41087;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -3.6440768429529538 9.290688162234483 -0.21473290902798753 ;
	setAttr ".cbx" -type "double3" 3.6440768429529538 9.4333091973328678 0.22802686005660691 ;
createNode polyTweak -n "polyTweak57";
	rename -uid "8CF52B8C-443E-3ED5-E47F-6E964A4EFC1C";
	setAttr ".uopa" yes;
	setAttr -s 28 ".tk";
	setAttr ".tk[75]" -type "float3" 0 9.3132257e-010 -1.8626451e-009 ;
	setAttr ".tk[78]" -type "float3" 0 -9.3132257e-010 -3.7252903e-009 ;
	setAttr ".tk[80]" -type "float3" 0 -9.3132257e-010 -3.7252903e-009 ;
	setAttr ".tk[81]" -type "float3" 0 9.3132257e-010 -1.8626451e-009 ;
	setAttr ".tk[86]" -type "float3" 0.058605056 0.12901556 0.044326518 ;
	setAttr ".tk[87]" -type "float3" 0.060044311 0.14876458 -0.044326518 ;
	setAttr ".tk[88]" -type "float3" 0.038250685 0.043481223 0.041808739 ;
	setAttr ".tk[89]" -type "float3" 0.03297 0.032139152 -0.044326518 ;
	setAttr ".tk[90]" -type "float3" 0.061326448 0.14731418 0.033370793 ;
	setAttr ".tk[91]" -type "float3" 0.058104295 0.12836638 -0.033370793 ;
	setAttr ".tk[92]" -type "float3" 0.032874595 0.034129862 0.033370793 ;
	setAttr ".tk[93]" -type "float3" 0.036914777 0.045355864 -0.031475317 ;
	setAttr ".tk[94]" -type "float3" -0.058104295 0.12836638 -0.033370793 ;
	setAttr ".tk[95]" -type "float3" -0.061326448 0.14731418 0.033370789 ;
	setAttr ".tk[96]" -type "float3" -0.036914777 0.045355864 -0.031475317 ;
	setAttr ".tk[97]" -type "float3" -0.032874595 0.034129862 0.033370789 ;
	setAttr ".tk[98]" -type "float3" -0.060044311 0.14876458 -0.044326518 ;
	setAttr ".tk[99]" -type "float3" -0.058605056 0.12901556 0.044326518 ;
	setAttr ".tk[100]" -type "float3" -0.03297 0.032139152 -0.044326518 ;
	setAttr ".tk[101]" -type "float3" -0.038250685 0.043481223 0.041808739 ;
	setAttr ".tk[102]" -type "float3" 0.19918403 0.010800621 0.092758767 ;
	setAttr ".tk[103]" -type "float3" 0.19915767 -0.010800621 0.094369158 ;
	setAttr ".tk[104]" -type "float3" 0.050906394 0.010800621 0.0098239593 ;
	setAttr ".tk[105]" -type "float3" 0.050880034 -0.010800621 0.011434353 ;
	setAttr ".tk[106]" -type "float3" -0.19918403 0.010800621 0.092758767 ;
	setAttr ".tk[107]" -type "float3" -0.19915767 -0.010800621 0.094369158 ;
	setAttr ".tk[108]" -type "float3" -0.050880034 -0.010800621 0.011434353 ;
	setAttr ".tk[109]" -type "float3" -0.050906394 0.010800621 0.0098239593 ;
createNode polyExtrudeFace -n "polyExtrudeFace40";
	rename -uid "AC3F40F0-4E2C-2059-1FB7-018FFA253B74";
	setAttr ".ics" -type "componentList" 2 "f[77]" "f[79]";
	setAttr ".ix" -type "matrix" 1.4143203331720728 0 0 0 0 1.4143203331720728 0 0 0 0 1.4143203331720728 0
		 0 8.1516316382320664 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 9.2463665 0.52286756 ;
	setAttr ".rs" 42002;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -3.4423784936657125 9.1504518072632877 0.4614947411040678 ;
	setAttr ".cbx" -type "double3" 3.4423784936657125 9.3422816542029139 0.58424043510702572 ;
createNode polyTweak -n "polyTweak58";
	rename -uid "5AAC644A-401F-BF67-7A8F-568ACE22C7F2";
	setAttr ".uopa" yes;
	setAttr -s 16 ".tk[110:125]" -type "float3"  0.13310994 0.014309968 0.027766444
		 0.12559561 0.022396302 -0.031050975 0.15860803 -0.027649781 0.026096016 0.16070087
		 -0.034482621 -0.031050975 0.12492547 0.023535391 0.026753105 0.13218138 0.014690701
		 -0.04566294 0.16136105 -0.036207754 0.026753105 0.15866154 -0.029367987 -0.043606307
		 -0.13218138 0.014690701 -0.04566294 -0.12492547 0.023535391 0.026753105 -0.15866154
		 -0.029367987 -0.043606307 -0.16136105 -0.036207754 0.026753105 -0.12559561 0.022396302
		 -0.031050976 -0.13310994 0.014309968 0.027766444 -0.16070087 -0.034482621 -0.031050976
		 -0.15860803 -0.027649781 0.026096016;
createNode polyExtrudeFace -n "polyExtrudeFace41";
	rename -uid "3D93D986-4412-37D9-0847-6F86BCA8A495";
	setAttr ".ics" -type "componentList" 1 "f[14:15]";
	setAttr ".ix" -type "matrix" 1.4143203331720728 0 0 0 0 1.4143203331720728 0 0 0 0 1.4143203331720728 0
		 0 8.1516316382320664 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 7.4114499 0.062444102 ;
	setAttr ".rs" 43642;
	setAttr ".lt" -type "double3" -8.4654505627668186e-016 3.3306690738754696e-016 0.65621651794468194 ;
	setAttr ".kft" no;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.75229011997301887 7.162981934367167 -0.32713960096755346 ;
	setAttr ".cbx" -type "double3" 0.75229011997301887 7.6599181492909896 0.4520278020972987 ;
createNode polyTweak -n "polyTweak59";
	rename -uid "F7DED20A-482D-191B-1FC5-09B9C7C76540";
	setAttr ".uopa" yes;
	setAttr -s 100 ".tk";
	setAttr ".tk[2]" -type "float3" 0 -0.035485059 -0.020477235 ;
	setAttr ".tk[3]" -type "float3" 0 -0.035485059 -0.020477235 ;
	setAttr ".tk[4]" -type "float3" 0 0.018233342 0.020477235 ;
	setAttr ".tk[5]" -type "float3" 0 0.018233342 0.020477235 ;
	setAttr ".tk[6]" -type "float3" 0 0.11594457 -0.049839195 ;
	setAttr ".tk[7]" -type "float3" 0 0.11594457 -0.049839195 ;
	setAttr ".tk[8]" -type "float3" 0 0.017033378 -0.020566588 ;
	setAttr ".tk[12]" -type "float3" 0 0.017565774 0 ;
	setAttr ".tk[13]" -type "float3" 0 0.017033378 0.020566588 ;
	setAttr ".tk[14]" -type "float3" 0 0.017033378 0.020566588 ;
	setAttr ".tk[15]" -type "float3" 0 0.34032479 -0.073875435 ;
	setAttr ".tk[16]" -type "float3" 0 0.13302404 -0.065874517 ;
	setAttr ".tk[17]" -type "float3" 0 0.13302404 -0.065874517 ;
	setAttr ".tk[19]" -type "float3" 0 0.017033378 -0.020566588 ;
	setAttr ".tk[21]" -type "float3" 0 -0.03808663 0 ;
	setAttr ".tk[23]" -type "float3" 0 0.18268003 -0.23130517 ;
	setAttr ".tk[26]" -type "float3" 0 0.017033378 0.013611717 ;
	setAttr ".tk[28]" -type "float3" 0 -0.035485059 0.013552577 ;
	setAttr ".tk[30]" -type "float3" 0 0.017033378 -0.013611717 ;
	setAttr ".tk[31]" -type "float3" 0 -0.035485059 -0.013552577 ;
	setAttr ".tk[32]" -type "float3" 0 0.017033378 -0.013611717 ;
	setAttr ".tk[34]" -type "float3" 0 -0.035485059 -0.013552577 ;
	setAttr ".tk[36]" -type "float3" 0 0.017033378 0.013611717 ;
	setAttr ".tk[37]" -type "float3" 0 -0.035485059 0.013552577 ;
	setAttr ".tk[38]" -type "float3" 0 0.017033378 0.012664933 ;
	setAttr ".tk[39]" -type "float3" 0.0034379791 0.030523833 0 ;
	setAttr ".tk[40]" -type "float3" -2.3283064e-010 -0.035485059 0.012609907 ;
	setAttr ".tk[42]" -type "float3" 0 0.017033378 -0.012664933 ;
	setAttr ".tk[43]" -type "float3" 0 -0.035485059 -0.012609907 ;
	setAttr ".tk[44]" -type "float3" 0 0.017033378 -0.012664933 ;
	setAttr ".tk[45]" -type "float3" -0.0034379791 0.030523833 0 ;
	setAttr ".tk[46]" -type "float3" 0 -0.035485059 -0.012609907 ;
	setAttr ".tk[48]" -type "float3" 0 0.017033378 0.012664933 ;
	setAttr ".tk[49]" -type "float3" 2.3283064e-010 -0.035485059 0.012609907 ;
	setAttr ".tk[50]" -type "float3" -0.038402732 0.072603539 0.013838409 ;
	setAttr ".tk[51]" -type "float3" -0.041840702 0.13423915 0 ;
	setAttr ".tk[52]" -type "float3" 0 -0.035485063 0.013778285 ;
	setAttr ".tk[54]" -type "float3" -0.038402732 0.072603539 -0.013838409 ;
	setAttr ".tk[55]" -type "float3" 0 -0.035485063 -0.013778285 ;
	setAttr ".tk[56]" -type "float3" 0.038402732 0.072603539 -0.013838409 ;
	setAttr ".tk[57]" -type "float3" 0.041840702 0.13423915 0 ;
	setAttr ".tk[58]" -type "float3" 0 -0.035485063 -0.013778285 ;
	setAttr ".tk[60]" -type "float3" 0.038402732 0.072603539 0.013838409 ;
	setAttr ".tk[61]" -type "float3" 0 -0.035485063 0.013778285 ;
	setAttr ".tk[63]" -type "float3" 0.048717149 0.049661204 0 ;
	setAttr ".tk[64]" -type "float3" 0 -0.035485063 0.013778279 ;
	setAttr ".tk[67]" -type "float3" 0 -0.035485063 -0.013778295 ;
	setAttr ".tk[69]" -type "float3" -0.048717149 0.049661204 0 ;
	setAttr ".tk[70]" -type "float3" 0 -0.035485063 -0.013778295 ;
	setAttr ".tk[73]" -type "float3" 0 -0.035485063 0.013778279 ;
	setAttr ".tk[75]" -type "float3" -0.041645538 0.049661204 0 ;
	setAttr ".tk[81]" -type "float3" 0.041645538 0.049661204 0 ;
	setAttr ".tk[86]" -type "float3" -0.03365786 -0.13033608 0 ;
	setAttr ".tk[87]" -type "float3" -0.048371151 -0.13098466 0 ;
	setAttr ".tk[88]" -type "float3" 0.031026686 -0.14068562 0 ;
	setAttr ".tk[89]" -type "float3" 0.039780326 -0.14446396 0 ;
	setAttr ".tk[90]" -type "float3" -0.042509314 -0.12561435 0 ;
	setAttr ".tk[91]" -type "float3" -0.027402975 -0.12575851 0 ;
	setAttr ".tk[92]" -type "float3" 0.048874892 -0.13932598 0 ;
	setAttr ".tk[93]" -type "float3" 0.039659675 -0.13626522 0 ;
	setAttr ".tk[94]" -type "float3" 0.027402975 -0.12575851 0 ;
	setAttr ".tk[95]" -type "float3" 0.042509314 -0.12561435 0 ;
	setAttr ".tk[96]" -type "float3" -0.039659675 -0.13626522 0 ;
	setAttr ".tk[97]" -type "float3" -0.048874892 -0.13932598 0 ;
	setAttr ".tk[98]" -type "float3" 0.048371151 -0.13098466 0 ;
	setAttr ".tk[99]" -type "float3" 0.03365786 -0.13033608 0 ;
	setAttr ".tk[100]" -type "float3" -0.039780326 -0.14446396 0 ;
	setAttr ".tk[101]" -type "float3" -0.031026686 -0.14068562 0 ;
	setAttr ".tk[102]" -type "float3" 0.087308429 -0.0366388 0.020045718 ;
	setAttr ".tk[103]" -type "float3" 0.085478701 -0.0366388 0.021494495 ;
	setAttr ".tk[104]" -type "float3" 0.026213925 -0.0366388 -0.023006754 ;
	setAttr ".tk[105]" -type "float3" 0.024384167 -0.0366388 -0.021557963 ;
	setAttr ".tk[106]" -type "float3" -0.087308429 -0.0366388 0.020045718 ;
	setAttr ".tk[107]" -type "float3" -0.085478701 -0.0366388 0.021494495 ;
	setAttr ".tk[108]" -type "float3" -0.024384167 -0.0366388 -0.021557963 ;
	setAttr ".tk[109]" -type "float3" -0.026213925 -0.0366388 -0.023006754 ;
	setAttr ".tk[110]" -type "float3" 0.012955886 -0.25659972 0 ;
	setAttr ".tk[111]" -type "float3" 0.010134746 -0.25620988 0 ;
	setAttr ".tk[112]" -type "float3" 0.024898462 -0.26082328 0 ;
	setAttr ".tk[113]" -type "float3" 0.026431644 -0.26184705 0 ;
	setAttr ".tk[114]" -type "float3" 0.0099664489 -0.25645357 0.007872168 ;
	setAttr ".tk[115]" -type "float3" 0.012772624 -0.25699568 -0.007872168 ;
	setAttr ".tk[116]" -type "float3" 0.026505666 -0.26212251 0.007872168 ;
	setAttr ".tk[117]" -type "float3" 0.02489505 -0.26123866 -0.0074250265 ;
	setAttr ".tk[118]" -type "float3" -0.012772624 -0.25699568 -0.007872168 ;
	setAttr ".tk[119]" -type "float3" -0.0099664489 -0.25645357 0.007872168 ;
	setAttr ".tk[120]" -type "float3" -0.02489505 -0.26123866 -0.0074250265 ;
	setAttr ".tk[121]" -type "float3" -0.026505666 -0.26212251 0.007872168 ;
	setAttr ".tk[122]" -type "float3" -0.010134746 -0.25620988 0 ;
	setAttr ".tk[123]" -type "float3" -0.012955886 -0.25659972 0 ;
	setAttr ".tk[124]" -type "float3" -0.026431644 -0.26184705 0 ;
	setAttr ".tk[125]" -type "float3" -0.024898462 -0.26082328 0 ;
	setAttr ".tk[126]" -type "float3" 0.31924611 -0.054970026 -0.03470761 ;
	setAttr ".tk[127]" -type "float3" 0.3197602 -0.16157393 -0.032448739 ;
	setAttr ".tk[128]" -type "float3" 0.19252551 -0.054970026 0.013916362 ;
	setAttr ".tk[129]" -type "float3" 0.19303977 -0.16157393 0.016175382 ;
	setAttr ".tk[130]" -type "float3" -0.31924611 -0.054970026 -0.03470761 ;
	setAttr ".tk[131]" -type "float3" -0.3197602 -0.16157393 -0.032448739 ;
	setAttr ".tk[132]" -type "float3" -0.19303977 -0.16157393 0.016175382 ;
	setAttr ".tk[133]" -type "float3" -0.19252551 -0.054970026 0.013916362 ;
createNode polyTweak -n "polyTweak60";
	rename -uid "5C08EF97-4BC0-F2CF-64B3-14AA8ABD3805";
	setAttr ".uopa" yes;
	setAttr -s 51 ".tk";
	setAttr ".tk[6]" -type "float3" 0 0.18203689 0.061544303 ;
	setAttr ".tk[7]" -type "float3" 0 0.18203689 0.061544303 ;
	setAttr ".tk[15]" -type "float3" 0 0.044891823 0.061544303 ;
	setAttr ".tk[16]" -type "float3" 0 0.089688152 -0.066289507 ;
	setAttr ".tk[17]" -type "float3" 0 0.089688152 -0.066289507 ;
	setAttr ".tk[22]" -type "float3" 0 0.12079248 0 ;
	setAttr ".tk[23]" -type "float3" 0 0.19612671 -0.063805453 ;
	setAttr ".tk[26]" -type "float3" 0.19068642 0 0 ;
	setAttr ".tk[27]" -type "float3" 0.18615133 0 0 ;
	setAttr ".tk[28]" -type "float3" 0.19161153 0 0 ;
	setAttr ".tk[29]" -type "float3" 0.18831286 0 0 ;
	setAttr ".tk[30]" -type "float3" 0.18903254 0 0 ;
	setAttr ".tk[31]" -type "float3" 0.19009006 0 0 ;
	setAttr ".tk[32]" -type "float3" -0.18903254 0 0 ;
	setAttr ".tk[33]" -type "float3" -0.18615133 0 0 ;
	setAttr ".tk[34]" -type "float3" -0.19009006 0 0 ;
	setAttr ".tk[35]" -type "float3" -0.18831286 0 0 ;
	setAttr ".tk[36]" -type "float3" -0.19068642 0 0 ;
	setAttr ".tk[37]" -type "float3" -0.19161153 0 0 ;
	setAttr ".tk[38]" -type "float3" -0.18498456 0 0 ;
	setAttr ".tk[39]" -type "float3" -0.19161153 0 0 ;
	setAttr ".tk[40]" -type "float3" -0.18412371 0 0 ;
	setAttr ".tk[41]" -type "float3" -0.18719284 0 0 ;
	setAttr ".tk[42]" -type "float3" -0.1865232 0 0 ;
	setAttr ".tk[43]" -type "float3" -0.18553934 0 0 ;
	setAttr ".tk[44]" -type "float3" 0.1865232 0 0 ;
	setAttr ".tk[45]" -type "float3" 0.19161153 0 0 ;
	setAttr ".tk[46]" -type "float3" 0.18553934 0 0 ;
	setAttr ".tk[47]" -type "float3" 0.18719284 0 0 ;
	setAttr ".tk[48]" -type "float3" 0.18498456 0 0 ;
	setAttr ".tk[49]" -type "float3" 0.18412371 0 0 ;
	setAttr ".tk[50]" -type "float3" -0.025248285 0 0 ;
	setAttr ".tk[51]" -type "float3" -0.025248285 0 0 ;
	setAttr ".tk[52]" -type "float3" -0.025248285 0 0 ;
	setAttr ".tk[53]" -type "float3" -0.025248285 0 0 ;
	setAttr ".tk[54]" -type "float3" -0.025248285 0 0 ;
	setAttr ".tk[55]" -type "float3" -0.025248285 0 0 ;
	setAttr ".tk[56]" -type "float3" 0.025248285 0 0 ;
	setAttr ".tk[57]" -type "float3" 0.025248285 0 0 ;
	setAttr ".tk[58]" -type "float3" 0.025248285 0 0 ;
	setAttr ".tk[59]" -type "float3" 0.025248285 0 0 ;
	setAttr ".tk[60]" -type "float3" 0.025248285 0 0 ;
	setAttr ".tk[61]" -type "float3" 0.025248285 0 0 ;
	setAttr ".tk[134]" -type "float3" 0 -0.54214114 -0.18412057 ;
	setAttr ".tk[135]" -type "float3" 0 -0.29140273 -0.18412057 ;
	setAttr ".tk[136]" -type "float3" 0 -0.64275998 -0.18412057 ;
	setAttr ".tk[137]" -type "float3" 0 -0.40911874 -0.18412057 ;
	setAttr ".tk[138]" -type "float3" 0 -0.29140273 -0.18412057 ;
	setAttr ".tk[139]" -type "float3" 0 -0.54214114 -0.18412057 ;
	setAttr ".tk[140]" -type "float3" 0 -0.4091188 -0.18412057 ;
	setAttr ".tk[141]" -type "float3" 0 -0.64275998 -0.18412057 ;
createNode polySplit -n "polySplit16";
	rename -uid "B586C27F-4EDF-4B24-6ECC-F0967070CFC6";
	setAttr -s 7 ".e[0:6]"  0.1 0.1 0.1 0.1 0.1 0.1 0.1;
	setAttr -s 7 ".d[0:6]"  -2147483590 -2147483587 -2147483585 -2147483581 -2147483583 -2147483589 
		-2147483590;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit17";
	rename -uid "0C6E6C47-4961-2880-235C-9DA354CF021F";
	setAttr -s 7 ".e[0:6]"  0.1 0.1 0.1 0.1 0.1 0.1 0.1;
	setAttr -s 7 ".d[0:6]"  -2147483602 -2147483599 -2147483597 -2147483593 -2147483595 -2147483601 
		-2147483602;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyExtrudeFace -n "polyExtrudeFace42";
	rename -uid "56AF1FF9-427D-24BF-6692-A885DC7286CD";
	setAttr ".ics" -type "componentList" 1 "f[14:15]";
	setAttr ".ix" -type "matrix" 1.4143203331720728 0 0 0 0 1.4143203331720728 0 0 0 0 1.4143203331720728 0
		 0 8.1516316382320664 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 6.1783066 0.037989821 ;
	setAttr ".rs" 61358;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.77468889909613559 6.17830444937929 -0.28115769008851033 ;
	setAttr ".cbx" -type "double3" 0.77468889909613559 6.178309001582587 0.35713733511948503 ;
createNode polyTweak -n "polyTweak61";
	rename -uid "CFA57105-4AA1-34DA-8E78-F391F48ADCE9";
	setAttr ".uopa" yes;
	setAttr -s 31 ".tk";
	setAttr ".tk[4]" -type "float3" 0 0.019531937 0 ;
	setAttr ".tk[5]" -type "float3" 0 0.019531937 0 ;
	setAttr ".tk[6]" -type "float3" 0 0.064340904 -0.022844821 ;
	setAttr ".tk[7]" -type "float3" 0 0.064340904 -0.022844821 ;
	setAttr ".tk[9]" -type "float3" 0 -0.063712217 0 ;
	setAttr ".tk[10]" -type "float3" 0 0.023711056 0 ;
	setAttr ".tk[11]" -type "float3" 0 0.023711056 0 ;
	setAttr ".tk[13]" -type "float3" 0 -0.052678369 0 ;
	setAttr ".tk[14]" -type "float3" 0 -0.052678369 0 ;
	setAttr ".tk[15]" -type "float3" 0 0.064340904 -0.022844821 ;
	setAttr ".tk[22]" -type "float3" 0 -0.052678369 0 ;
	setAttr ".tk[134]" -type "float3" -0.17458083 -7.0015133e-008 0.0099143703 ;
	setAttr ".tk[135]" -type "float3" -0.083699726 1.6934234e-007 0.093579471 ;
	setAttr ".tk[136]" -type "float3" -0.087175936 -1.6934234e-007 0.027036093 ;
	setAttr ".tk[137]" -type "float3" -0.083699726 5.6447391e-008 -0.0060249479 ;
	setAttr ".tk[138]" -type "float3" 0.083699726 1.6934234e-007 0.093579374 ;
	setAttr ".tk[139]" -type "float3" 0.17458083 -7.0015133e-008 0.0099143051 ;
	setAttr ".tk[140]" -type "float3" 0.083699726 5.6447391e-008 -0.0060250224 ;
	setAttr ".tk[141]" -type "float3" 0.087175936 -1.6934234e-007 0.027036034 ;
	setAttr ".tk[142]" -type "float3" -0.046291485 0.0068877353 -0.016441114 ;
	setAttr ".tk[143]" -type "float3" -0.057005472 -0.021989424 -0.0283772 ;
	setAttr ".tk[144]" -type "float3" -0.039000049 -0.011786073 0 ;
	setAttr ".tk[145]" -type "float3" -0.07242097 -0.045230377 0.025043586 ;
	setAttr ".tk[146]" -type "float3" -0.063047051 0.0068877353 0.016441114 ;
	setAttr ".tk[147]" -type "float3" -0.017099697 0.011786073 0 ;
	setAttr ".tk[148]" -type "float3" 0.063047051 0.0068877353 0.016441114 ;
	setAttr ".tk[149]" -type "float3" 0.07242097 -0.045230377 0.025043586 ;
	setAttr ".tk[150]" -type "float3" 0.039000049 -0.011786073 0 ;
	setAttr ".tk[151]" -type "float3" 0.057005472 -0.021989424 -0.0283772 ;
	setAttr ".tk[152]" -type "float3" 0.046291485 0.0068877353 -0.016441114 ;
	setAttr ".tk[153]" -type "float3" 0.017099697 0.011786073 0 ;
createNode polyExtrudeFace -n "polyExtrudeFace43";
	rename -uid "2B80BE4E-4D44-339F-466D-2194F0E077E2";
	setAttr ".ics" -type "componentList" 1 "f[14:15]";
	setAttr ".ix" -type "matrix" 1.4143203331720728 0 0 0 0 1.4143203331720728 0 0 0 0 1.4143203331720728 0
		 0 8.1516316382320664 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 4.8527522 0.037989844 ;
	setAttr ".rs" 57008;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.64709194732948083 4.8527503944993686 -0.18980318917174652 ;
	setAttr ".cbx" -type "double3" 0.64709194732948083 4.8527537665018103 0.26578287635275172 ;
createNode polyTweak -n "polyTweak62";
	rename -uid "3A982BE2-4C26-C58F-4FEF-CAB21EADE468";
	setAttr ".uopa" yes;
	setAttr -s 16 ".tk";
	setAttr ".tk[134]" -type "float3" -0.025881529 0 0.027753783 ;
	setAttr ".tk[135]" -type "float3" 0.025881531 0 0.027753783 ;
	setAttr ".tk[136]" -type "float3" -0.02588143 0 0.027753783 ;
	setAttr ".tk[137]" -type "float3" 0.025881531 0 0.027753783 ;
	setAttr ".tk[138]" -type "float3" -0.025881531 0 0.027753783 ;
	setAttr ".tk[139]" -type "float3" 0.025881529 0 0.027753783 ;
	setAttr ".tk[140]" -type "float3" -0.025881531 0 0.027753783 ;
	setAttr ".tk[141]" -type "float3" 0.02588143 0 0.027753783 ;
	setAttr ".tk[154]" -type "float3" -0.090217866 -0.93723786 0.04118751 ;
	setAttr ".tk[155]" -type "float3" 0.090217859 -0.93723726 0.064592533 ;
	setAttr ".tk[156]" -type "float3" -0.090217531 -0.93723834 -0.050337385 ;
	setAttr ".tk[157]" -type "float3" 0.090217859 -0.93723774 -0.064592466 ;
	setAttr ".tk[158]" -type "float3" -0.090217859 -0.93723726 0.06459251 ;
	setAttr ".tk[159]" -type "float3" 0.090217866 -0.93723786 0.041187488 ;
	setAttr ".tk[160]" -type "float3" -0.090217859 -0.93723774 -0.06459251 ;
	setAttr ".tk[161]" -type "float3" 0.090217531 -0.93723834 -0.050337411 ;
createNode polyExtrudeFace -n "polyExtrudeFace44";
	rename -uid "E2EC39E7-4A76-ABDC-B9F8-F1A4359E3B2B";
	setAttr ".ics" -type "componentList" 1 "f[14:15]";
	setAttr ".ix" -type "matrix" 1.4143203331720728 0 0 0 0 1.4143203331720728 0 0 0 0 1.4143203331720728 0
		 0 8.1516316382320664 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 4.745924 0.084022 ;
	setAttr ".rs" 49312;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.68101521919962338 4.7459216479248285 -0.28933627126214018 ;
	setAttr ".cbx" -type "double3" 0.68101521919962338 4.7459263687282478 0.45738026587401198 ;
createNode polyTweak -n "polyTweak63";
	rename -uid "28515BF6-47B7-35A3-D872-C48B11E99D4B";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk[162:169]" -type "float3"  0.023985565 -0.075532734 -0.033081379
		 -0.023985565 -0.075533107 -0.070375189 0.023985468 -0.075532585 0.1127553 -0.023985565
		 -0.075533003 0.13546948 0.023985565 -0.075533107 -0.070375152 -0.023985565 -0.075532734
		 -0.033081349 0.023985565 -0.075533003 0.13546957 -0.023985468 -0.075532585 0.11275534;
createNode polyExtrudeFace -n "polyExtrudeFace45";
	rename -uid "4669CFA6-4ADE-0186-3817-F59A84BD7236";
	setAttr ".ics" -type "componentList" 1 "f[14:15]";
	setAttr ".ix" -type "matrix" 1.4143203331720728 0 0 0 0 1.4143203331720728 0 0 0 0 1.4143203331720728 0
		 0 8.1516316382320664 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 4.6199946 0.14311934 ;
	setAttr ".rs" 53650;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.68101526134965396 4.6199921935159178 -0.40333676123107137 ;
	setAttr ".cbx" -type "double3" 0.68101526134965396 4.6199972515195817 0.68957542674965977 ;
createNode polyTweak -n "polyTweak64";
	rename -uid "0EDDCE74-4AD3-36F2-66F9-11A71EA4A819";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk[170:177]" -type "float3"  0 -0.089038469 -0.036256749
		 0 -0.089038469 -0.080604427 0 -0.089038469 0.13716382 0 -0.089038469 0.16417429 0
		 -0.089038469 -0.080604419 0 -0.089038469 -0.036256734 0 -0.089038469 0.16417438 0
		 -0.089038469 0.13716394;
createNode polySplitRing -n "polySplitRing9";
	rename -uid "CD478707-4F46-5DD4-6174-CFB79C496414";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 3 "e[272:273]" "e[275]" "e[277]";
	setAttr ".ix" -type "matrix" 1.4143203331720728 0 0 0 0 1.4143203331720728 0 0 0 0 1.4143203331720728 0
		 0 8.1516316382320664 0 1;
	setAttr ".wt" 0.66906392574310303;
	setAttr ".dr" no;
	setAttr ".re" 277;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".div" 1;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak65";
	rename -uid "D8FF3B3E-4AA4-48FD-195E-2DAF4265AD80";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk[178:185]" -type "float3"  -0.0055845939 -0.055193897
		 0.0089180022 0.0055845939 -0.055193786 0.013985705 -0.0055845715 -0.05519392 -0.010899149
		 0.0055845939 -0.055193823 -0.013985693 -0.0055845939 -0.055193786 0.013985701 0.0055845939
		 -0.055193897 0.0089179976 -0.0055845939 -0.055193823 -0.013985701 0.0055845715 -0.05519392
		 -0.010899158;
createNode polySplitRing -n "polySplitRing10";
	rename -uid "DDBB18FF-477D-179A-8A17-E1B8699E5923";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 3 "e[264:265]" "e[267]" "e[269]";
	setAttr ".ix" -type "matrix" 1.4143203331720728 0 0 0 0 1.4143203331720728 0 0 0 0 1.4143203331720728 0
		 0 8.1516316382320664 0 1;
	setAttr ".wt" 0.56961220502853394;
	setAttr ".dr" no;
	setAttr ".re" 269;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".div" 1;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polySplitRing -n "polySplitRing11";
	rename -uid "CDC8A38D-4AA0-6237-2BBE-32834AA4B5DF";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 3 "e[312:313]" "e[315]" "e[317]";
	setAttr ".ix" -type "matrix" 1.4143203331720728 0 0 0 0 1.4143203331720728 0 0 0 0 1.4143203331720728 0
		 0 8.1516316382320664 0 1;
	setAttr ".wt" 0.26552110910415649;
	setAttr ".re" 315;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".div" 1;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak66";
	rename -uid "C51E6B7A-4D76-9258-A83A-0BAA9F88BAD3";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk[186:193]" -type "float3"  -0.031510416 -0.43414158 -0.025132161
		 -0.083850361 -0.31731981 -0.033460002 -0.083850361 -0.35652333 0.033460002 -0.026023468
		 -0.42867473 0.018098162 0.083850361 -0.31731981 -0.033459999 0.031510416 -0.43414158
		 -0.025132148 0.026023468 -0.42867473 0.018098172 0.083850361 -0.35652333 0.033460006;
createNode polySplitRing -n "polySplitRing12";
	rename -uid "47605CE6-44DC-DADD-24E0-C7B716AF73E0";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 3 "e[304:305]" "e[307]" "e[309]";
	setAttr ".ix" -type "matrix" 1.4143203331720728 0 0 0 0 1.4143203331720728 0 0 0 0 1.4143203331720728 0
		 0 8.1516316382320664 0 1;
	setAttr ".wt" 0.3080538809299469;
	setAttr ".re" 309;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".div" 1;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyExtrudeFace -n "polyExtrudeFace46";
	rename -uid "A6D1DA12-46F0-20A7-5683-7BA289C6A0C1";
	setAttr ".ics" -type "componentList" 1 "f[4:7]";
	setAttr ".ix" -type "matrix" 1.4143203331720728 0 0 0 0 1.4143203331720728 0 0 0 0 1.4143203331720728 0
		 0 3.6131058433424825 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 4.8637695 0.018115746 ;
	setAttr ".rs" 40092;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.69814629825742003 4.7834941710380781 -0.49413863309757383 ;
	setAttr ".cbx" -type "double3" 0.69814629825742003 4.9440453233229906 0.53037012493952729 ;
createNode polyTweak -n "polyTweak67";
	rename -uid "1C4EA040-4B40-BECC-8541-E1B796C3B624";
	setAttr ".uopa" yes;
	setAttr -s 67 ".tk";
	setAttr ".tk[0]" -type "float3" 0.048302718 0 0 ;
	setAttr ".tk[1]" -type "float3" -0.048302718 0 0 ;
	setAttr ".tk[8]" -type "float3" 0.0041556107 -0.065555416 0.0076128789 ;
	setAttr ".tk[13]" -type "float3" -0.0037243166 0.0024120663 -0.0048306417 ;
	setAttr ".tk[14]" -type "float3" 0.0037243166 0.0024120663 -0.0048306417 ;
	setAttr ".tk[16]" -type "float3" 0.090813696 0 0.012302309 ;
	setAttr ".tk[17]" -type "float3" -0.090813696 0 0.012302309 ;
	setAttr ".tk[19]" -type "float3" -0.0041556107 -0.065555416 0.0076128789 ;
	setAttr ".tk[20]" -type "float3" 0 0.12973273 -0.03531028 ;
	setAttr ".tk[22]" -type "float3" 0 0.001163539 -0.0068798633 ;
	setAttr ".tk[23]" -type "float3" 0 -0.0010457608 0.00032175193 ;
	setAttr ".tk[134]" -type "float3" -0.13884199 0 -0.02471631 ;
	setAttr ".tk[135]" -type "float3" -0.022343928 0 0.0032351296 ;
	setAttr ".tk[136]" -type "float3" -0.10783512 0 -0.015053344 ;
	setAttr ".tk[137]" -type "float3" -0.0540848 0 -0.015053344 ;
	setAttr ".tk[138]" -type "float3" 0.022343928 0 0.0032351071 ;
	setAttr ".tk[139]" -type "float3" 0.13884199 0 -0.024716338 ;
	setAttr ".tk[140]" -type "float3" 0.0540848 0 -0.015053344 ;
	setAttr ".tk[141]" -type "float3" 0.10783512 0 -0.015053344 ;
	setAttr ".tk[154]" -type "float3" -0.10783512 0 0 ;
	setAttr ".tk[155]" -type "float3" -0.0540848 0 0 ;
	setAttr ".tk[156]" -type "float3" -0.10783512 0 0 ;
	setAttr ".tk[157]" -type "float3" -0.0540848 0 0 ;
	setAttr ".tk[158]" -type "float3" 0.0540848 0 0 ;
	setAttr ".tk[159]" -type "float3" 0.10783512 0 0 ;
	setAttr ".tk[160]" -type "float3" 0.0540848 0 0 ;
	setAttr ".tk[161]" -type "float3" 0.10783512 0 0 ;
	setAttr ".tk[162]" -type "float3" -0.10783512 0 0 ;
	setAttr ".tk[163]" -type "float3" -0.0540848 0 0 ;
	setAttr ".tk[164]" -type "float3" -0.10783512 0 0 ;
	setAttr ".tk[165]" -type "float3" -0.0540848 0 0 ;
	setAttr ".tk[166]" -type "float3" 0.0540848 0 0 ;
	setAttr ".tk[167]" -type "float3" 0.10783512 0 0 ;
	setAttr ".tk[168]" -type "float3" 0.0540848 0 0 ;
	setAttr ".tk[169]" -type "float3" 0.10783512 0 0 ;
	setAttr ".tk[170]" -type "float3" -0.10783512 0 0 ;
	setAttr ".tk[171]" -type "float3" -0.0540848 0 0 ;
	setAttr ".tk[172]" -type "float3" -0.10783512 0 0 ;
	setAttr ".tk[173]" -type "float3" -0.0540848 0 0 ;
	setAttr ".tk[174]" -type "float3" 0.0540848 0 0 ;
	setAttr ".tk[175]" -type "float3" 0.10783512 0 0 ;
	setAttr ".tk[176]" -type "float3" 0.0540848 0 0 ;
	setAttr ".tk[177]" -type "float3" 0.10783512 0 0 ;
	setAttr ".tk[178]" -type "float3" -0.10783512 -9.9358738e-007 0 ;
	setAttr ".tk[179]" -type "float3" -0.0540848 1.4992795e-006 0 ;
	setAttr ".tk[180]" -type "float3" -0.10783512 -1.4992794e-006 0 ;
	setAttr ".tk[181]" -type "float3" -0.0540848 8.2197431e-007 0 ;
	setAttr ".tk[182]" -type "float3" 0.0540848 1.4992795e-006 0 ;
	setAttr ".tk[183]" -type "float3" 0.10783512 -9.9358738e-007 0 ;
	setAttr ".tk[184]" -type "float3" 0.0540848 8.2197431e-007 0 ;
	setAttr ".tk[185]" -type "float3" 0.10783512 -1.4992794e-006 0 ;
	setAttr ".tk[186]" -type "float3" 0.098263279 3.9732605e-008 0.012293682 ;
	setAttr ".tk[187]" -type "float3" 0.06634064 -3.9732605e-008 0.016367346 ;
	setAttr ".tk[188]" -type "float3" 0.044154394 0.0010457529 0.021265501 ;
	setAttr ".tk[189]" -type "float3" 0.16106038 3.9732605e-008 -0.014935804 ;
	setAttr ".tk[190]" -type "float3" -0.06634064 -3.9732605e-008 0.016367342 ;
	setAttr ".tk[191]" -type "float3" -0.098263279 3.9732605e-008 0.01229368 ;
	setAttr ".tk[192]" -type "float3" -0.16106038 3.9732605e-008 -0.014935796 ;
	setAttr ".tk[193]" -type "float3" -0.044154394 0.0010457519 0.021265516 ;
	setAttr ".tk[194]" -type "float3" 0.074370675 0.39135689 0.024143368 ;
	setAttr ".tk[195]" -type "float3" 0.052421238 0.39135656 -0.012585301 ;
	setAttr ".tk[196]" -type "float3" 0.10876468 0.39135689 -0.030778546 ;
	setAttr ".tk[197]" -type "float3" 0.087549321 0.39135721 0.018815096 ;
	setAttr ".tk[198]" -type "float3" -0.074370675 0.39135689 0.024143348 ;
	setAttr ".tk[199]" -type "float3" -0.087549321 0.39135721 0.018815087 ;
	setAttr ".tk[200]" -type "float3" -0.10876468 0.39135689 -0.030778522 ;
	setAttr ".tk[201]" -type "float3" -0.052421238 0.39135656 -0.012585284 ;
createNode polyExtrudeFace -n "polyExtrudeFace47";
	rename -uid "75C4D47E-4730-ABBE-5E47-D6845CB7CB17";
	setAttr ".ics" -type "componentList" 1 "f[4:7]";
	setAttr ".ix" -type "matrix" 1.4143203331720728 0 0 0 0 1.4143203331720728 0 0 0 0 1.4143203331720728 0
		 0 3.6131058433424825 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 5.0081005 0.049234461 ;
	setAttr ".rs" 40330;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.31367833539275053 4.9856915766867793 -0.19348737581515041 ;
	setAttr ".cbx" -type "double3" 0.31367833539275053 5.0305097041479101 0.29195629608478685 ;
createNode polyTweak -n "polyTweak68";
	rename -uid "A09B0E4F-4174-4D28-1EC1-CE8F9F2BBB9B";
	setAttr ".uopa" yes;
	setAttr -s 210 ".tk";
	setAttr ".tk[0:165]" -type "float3"  0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0;
	setAttr ".tk[166:209]" 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0 1.4901161e-008
		 0 0 1.4901161e-008 0 0 1.4901161e-008 0 0.25149974 0.14296436 -0.10664146 0 0.13578852
		 -0.16857131 0 0.061134901 0.028742203 0.27183938 0.072769523 0.028742203 -0.25149974
		 0.14296436 -0.10664146 -0.27183938 0.072769523 0.028742203 -0.23408598 0.090161785
		 0.16412587 0 0.07719966 0.21257649 0.23408598 0.090161785 0.16412587;
createNode polyCube -n "polyCube2";
	rename -uid "3695F2EB-44B7-11BE-0F07-68B4CA287DA4";
	setAttr ".cuv" 4;
createNode polySmoothFace -n "polySmoothFace2";
	rename -uid "2548CBCC-46A1-8B24-0694-BCBBFEA71205";
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".sdt" 2;
	setAttr ".suv" yes;
	setAttr ".ps" 0.10000000149011612;
	setAttr ".ro" 1;
	setAttr ".ma" yes;
	setAttr ".m08" yes;
createNode polySmoothFace -n "polySmoothFace3";
	rename -uid "2398D2D2-4263-858D-FAD5-6FBD8E784277";
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".sdt" 2;
	setAttr ".suv" yes;
	setAttr ".ps" 0.10000000149011612;
	setAttr ".ro" 1;
	setAttr ".ma" yes;
	setAttr ".m08" yes;
createNode polyTweak -n "polyTweak69";
	rename -uid "6430B18D-4F89-7639-7FBE-E5B7E32C2974";
	setAttr ".uopa" yes;
	setAttr -s 98 ".tk[0:97]" -type "float3"  -0.028949525 -0.041142616
		 0 0.028949525 -0.041142616 0 -0.028949525 0.041142616 0 0.028949525 0.041142616 0
		 -0.028949525 0.041142616 0 0.028949525 0.041142616 0 -0.028949525 -0.041142616 0
		 0.028949525 -0.041142616 0 0.036565233 -1.4754782e-014 0 0 0.051965933 0 -0.036565229
		 0.051965933 0 0.036565233 0.051965933 0 0 0.051965933 0 -0.036565229 -1.4754782e-014
		 0 0.036565233 -1.4754782e-014 0 0 -0.051965933 0 -0.036565229 -0.051965933 0 0.036565233
		 -0.051965933 0 0 -0.051965933 0 -0.036565229 -1.4754782e-014 0 2.1176914e-010 3.0094821e-010
		 0 2.1176914e-010 0.07097102 0 2.1176914e-010 -3.0097774e-010 0 2.1176914e-010 -0.07097102
		 0 0.049937945 3.0094821e-010 0 -0.049937945 3.0094821e-010 0 0 -0.028332295 0 -0.019935692
		 -1.4754782e-014 0 0.017172335 -0.048389316 0 0.03404858 -0.024405051 0 0.019935692
		 -1.4754782e-014 0 0 0.028332295 0 0.03404858 0.024405051 0 0.017172335 0.048389316
		 0 -0.03404858 0.024405051 0 -0.017172335 0.048389316 0 -0.03404858 0.048389316 0
		 0 0.066202201 0 -0.019935692 0.066202201 0 0.03404858 0.048389316 0 0.019935692 0.066202201
		 0 0 0.066202201 0 0.03404858 0.048389316 0 0.017172335 0.048389316 0 -0.03404858
		 0.048389316 0 -0.017172335 0.048389316 0 -0.03404858 0.024405051 0 0 0.028332295
		 0 -0.019935692 -1.4754782e-014 0 0.03404858 0.024405051 0 0.019935692 -1.4754782e-014
		 0 0 -0.028332295 0 0.03404858 -0.024405051 0 0.017172335 -0.048389316 0 -0.03404858
		 -0.024405051 0 -0.017172335 -0.048389316 0 -0.03404858 -0.048389316 0 0 -0.066202201
		 0 -0.019935692 -0.066202201 0 0.03404858 -0.048389316 0 0.019935692 -0.066202201
		 0 0 -0.066202201 0 0.03404858 -0.048389316 0 -0.03404858 -0.048389316 0 0.046582412
		 -0.028332295 0 0.046582412 -1.4754782e-014 0 0.046582412 -1.4754782e-014 0 0.046582412
		 0.028332295 0 -0.046582412 -0.028332295 0 -0.046582412 -1.4754782e-014 0 -0.046582412
		 -1.4754782e-014 0 -0.046582412 0.028332295 0 -0.017172335 -0.048389316 0 -0.03404858
		 -0.024405051 0 -0.018554017 -0.026368678 0 0.018554017 -0.026368678 0 0.018554017
		 0.026368678 0 -0.018554017 0.026368678 0 -0.018554017 0.061713926 0 0.018554017 0.061713926
		 0 0.018554017 0.061713926 0 -0.018554017 0.061713926 0 -0.018554017 0.026368678 0
		 0.018554017 0.026368678 0 0.018554017 -0.026368678 0 -0.018554017 -0.026368678 0
		 -0.018554017 -0.061713926 0 0.018554017 -0.061713926 0 0.018554017 -0.061713926 0
		 -0.018554017 -0.061713926 0 0.043424297 -0.026368678 0 0.043424297 -0.026368678 0
		 0.043424297 0.026368678 0 0.043424297 0.026368678 0 -0.043424297 -0.026368678 0 -0.043424297
		 -0.026368678 0 -0.043424297 0.026368678 0 -0.043424297 0.026368678 0;
createNode deleteComponent -n "deleteComponent7";
	rename -uid "27E4E41D-4BB0-AAA0-EF47-D592D1E4AD48";
	setAttr ".dc" -type "componentList" 3 "f[49:50]" "f[52]" "f[55]";
createNode polyCloseBorder -n "polyCloseBorder1";
	rename -uid "339287A7-4B44-08AA-F974-E7BD30490605";
	setAttr ".ics" -type "componentList" 2 "e[144]" "e[147]";
createNode polyTweak -n "polyTweak70";
	rename -uid "9D4508F8-4977-1117-A244-D184D2375ACA";
	setAttr ".uopa" yes;
	setAttr -s 97 ".tk[0:96]" -type "float3"  0.030716155 -0.12314903 0.0026188903
		 -0.030716155 -0.12314903 0.0026188903 -0.021468481 0.043126713 0.0064682001 0.021468481
		 0.043126713 0.0064682001 -0.017901434 0.039004453 0 0.017901434 0.039004453 0 0.034873925
		 -0.12029496 0.11421945 -0.034873925 -0.12029496 0.11421945 0.00057302276 -0.046617553
		 -0.001740301 0 0.059847329 0.0020612334 -0.022610728 0.05244505 5.4868214e-017 0.022610731
		 0.05244505 5.4868214e-017 0 0.052292835 0 0.01235812 -0.032804903 0.0085118078 -0.01235812
		 -0.032804903 0.0085118078 0 -0.13712868 0.13010231 0.043942083 -0.13697225 0.04684934
		 -0.043942098 -0.13697225 0.04684934 0 -0.1263018 -0.033730756 -0.00057301577 -0.046617553
		 -0.001740301 -8.5916296e-010 -0.054887597 -0.047476433 1.3095103e-010 0.071895912
		 7.4969596e-017 -2.5691478e-011 -0.027690174 0.0089906622 8.5533088e-011 -0.17022473
		 0.077008426 -0.0054696505 -0.026741276 3.645035e-011 0.0054696505 -0.026741276 -3.645035e-011
		 0 -0.093154497 -0.074806131 -0.013846675 -0.060219862 -0.030609068 0.0011854504 -0.12583753
		 -0.025288755 -0.04950472 -0.10649725 -0.04668548 0.013846682 -0.060219862 -0.030609068
		 -9.9011399e-010 0.024106745 -0.026154 0.031056486 0.019975493 0.0074326824 0.012970105
		 0.056438789 0.0057615163 -0.031056486 0.019975493 0.0074326824 -0.012970105 0.056438789
		 0.0057615163 -0.021054525 0.048066508 0 0 0.067064941 0 -0.012327576 0.067064941
		 6.9932072e-017 0.021054525 0.048066508 0 0.012327576 0.067064941 6.9932072e-017 0
		 0.067064941 0 0.021054525 0.048066508 0 0.010618804 0.047923375 0 -0.021054525 0.048066508
		 0 -0.010618804 0.047923375 0 -0.020766739 0.016235363 4.8905997e-005 0 0.022669356
		 0 0.0045995428 -0.030311124 0.0096424762 0.020766739 0.016235363 4.8905997e-005 -0.0045995428
		 -0.030311124 0.0096424762 0 -0.10300309 0.15851338 -0.062339466 -0.096648686 0.1284682
		 0.0039867763 -0.15069737 0.14939138 0.062339466 -0.096648686 0.1284682 -0.0039867763
		 -0.15069737 0.14939138 0.040317852 -0.13104706 0.086078532 -0.0071779033 -0.16106494
		 0.04684934 -0.040317852 -0.13104706 0.086078532 0.0071779033 -0.16106494 0.04684934
		 0 -0.16106494 0.0034456616 -0.040109769 -0.12947963 0.0090271626 0.040109769 -0.12947963
		 0.0090271626 -0.10142689 -0.10300309 0.04684934 -0.010361712 -0.029666079 -0.0040189722
		 -0.010361712 -0.029666079 0.0040189722 0.028805029 0.02309888 2.9206993e-017 0.10142689
		 -0.10300309 0.04684934 0.010361712 -0.029666079 0.0040189722 0.010361712 -0.029666079
		 -0.0040189722 -0.028805029 0.02309888 2.9206993e-017 -0.0011854504 -0.12583753 -0.025288755
		 0.04950472 -0.10649725 -0.04668548 -0.012935814 -0.1001403 -0.067311682 0.012935814
		 -0.1001403 -0.067311682 0.030061448 0.017389098 -0.0099849785 -0.030061448 0.017389098
		 -0.0099849785 -0.011473191 0.062518172 0 0.011473191 0.062518172 0 0.011473191 0.062518172
		 0 -0.011473191 0.062518172 0 -0.011473191 0.01931344 0 0.011473191 0.01931344 0 -0.014018793
		 -0.099825852 0.15094294 0.014018793 -0.099825852 0.15094294 -0.052326918 -0.15280107
		 0.087563552 0.052326918 -0.15280107 0.087563552 0.0088419011 -0.15260865 0.0063069072
		 -0.0088419011 -0.15260865 0.0063069072 -0.077727489 -0.099825852 0.0051467461 -0.091578119
		 -0.099825852 0.091325693 0.02685215 0.019763997 0 0.02685215 0.019763997 0 0.091578119
		 -0.099825852 0.091325693 0.077727489 -0.099825852 0.0051467461 -0.02685215 0.019763997
		 0 -0.02685215 0.019763997 0;
createNode polySplit -n "polySplit18";
	rename -uid "6D04EF2E-43E3-0C87-754E-0484A041D3F8";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483573 -2147483635;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit19";
	rename -uid "59AAC0A8-4467-77CA-D238-38B9751E3748";
	setAttr -s 3 ".e[0:2]"  1 0.54723299 1;
	setAttr -s 3 ".d[0:2]"  -2147483503 -2147483460 -2147483506;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyTweak -n "polyTweak71";
	rename -uid "F5B865B8-4FBC-0063-FFED-8BBE4B121E16";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk";
	setAttr ".tk[23]" -type "float3" 0 0.017792983 0 ;
	setAttr ".tk[85]" -type "float3" 0.013806949 0 0.014002482 ;
	setAttr ".tk[86]" -type "float3" -0.013806949 0 0.014002482 ;
	setAttr ".tk[97]" -type "float3" 0 -0.045768082 0 ;
createNode deleteComponent -n "deleteComponent8";
	rename -uid "669FE1F6-4494-7CED-D621-0C8F00A9AE85";
	setAttr ".dc" -type "componentList" 3 "f[43]" "f[46]" "f[92:93]";
createNode polyTweak -n "polyTweak72";
	rename -uid "B9773C9E-4B7F-9981-FC43-9887BB86C485";
	setAttr ".uopa" yes;
	setAttr -s 9 ".tk[209:217]" -type "float3"  0.10454047 0.15888765 -0.012651598
		 0 0.13964 -0.043285947 0 0.16320124 0.054317776 0.10790323 0.16770694 0.054317791
		 -0.10454047 0.15888765 -0.012651598 -0.10790323 0.16770694 0.054317791 -0.10166143
		 0.21044476 0.12128697 0 0.21830912 0.14525366 0.10166143 0.21044476 0.12128697;
createNode deleteComponent -n "deleteComponent9";
	rename -uid "A973A3E2-4252-56FC-1150-9E94529C3DF9";
	setAttr ".dc" -type "componentList" 1 "f[4:7]";
createNode polyUnite -n "polyUnite1";
	rename -uid "F4805FCC-413A-E005-DDB2-EE8F1B0E7CC9";
	setAttr -s 2 ".ip";
	setAttr -s 2 ".im";
createNode groupId -n "groupId5";
	rename -uid "135A7754-4171-CAC0-C0BC-6AB635A21C2F";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts3";
	rename -uid "A13AE8F9-49B6-B020-1510-A781E4EF342D";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "f[0:91]";
createNode groupId -n "groupId6";
	rename -uid "3C2DEF72-44E3-09AC-5F5A-F1B675AA6E71";
	setAttr ".ihi" 0;
createNode groupId -n "groupId7";
	rename -uid "CABB502E-4859-077C-AB01-BEB4ED7F1902";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts4";
	rename -uid "51754FEA-49CC-DA93-27DF-22A8A181444B";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "f[0:211]";
createNode groupId -n "groupId8";
	rename -uid "5290C0F1-4C64-AEC1-6C22-E1A94E70A894";
	setAttr ".ihi" 0;
createNode groupId -n "groupId9";
	rename -uid "8687F7CC-4AD9-5672-E26F-B78A27BFBC8A";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts5";
	rename -uid "78347550-41A6-1B4B-EBFB-BC94620B46EF";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "f[0:303]";
createNode polyTweakUV -n "polyTweakUV1";
	rename -uid "40FB781C-4A93-DE4B-F801-94BB62154799";
	setAttr ".uopa" yes;
	setAttr -s 4 ".uvtk";
	setAttr ".uvtk[59]" -type "float2" 0.028325457 0.0026321523 ;
	setAttr ".uvtk[62]" -type "float2" -0.028325457 0.0026321523 ;
	setAttr ".uvtk[348]" -type "float2" -4.7986615e-012 -0.011715241 ;
	setAttr ".uvtk[350]" -type "float2" -4.9292792e-012 -0.011715241 ;
createNode polyMergeVert -n "polyMergeVert1";
	rename -uid "80D1004B-437E-1784-12F5-7F898B5D33F8";
	setAttr ".ics" -type "componentList" 4 "vtx[52]" "vtx[54]" "vtx[308]" "vtx[310]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".d" 1e-006;
createNode polyTweak -n "polyTweak73";
	rename -uid "6DA15AB2-44D7-9B63-B3F9-C1B702B87D0F";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk";
	setAttr ".tk[52]" -type "float3" -0.0027742833 -0.014847279 -0.044664219 ;
	setAttr ".tk[54]" -type "float3" 0.0027742833 -0.014847279 -0.044664219 ;
	setAttr ".tk[308]" -type "float3" -0.0027742982 0.014847279 0.044664212 ;
	setAttr ".tk[310]" -type "float3" 0.0027742982 0.014847279 0.044664212 ;
createNode polyTweakUV -n "polyTweakUV2";
	rename -uid "879A0D4E-4A2E-85A5-DBE2-9E8903F95C4E";
	setAttr ".uopa" yes;
	setAttr -s 4 ".uvtk";
	setAttr ".uvtk[55]" -type "float2" 0.0045000021 0.033891562 ;
	setAttr ".uvtk[60]" -type "float2" -0.0045000236 0.033891562 ;
	setAttr ".uvtk[351]" -type "float2" -0.0069994805 -0.017491825 ;
	setAttr ".uvtk[353]" -type "float2" 0.0069994805 -0.017491825 ;
createNode polyMergeVert -n "polyMergeVert2";
	rename -uid "0B4A45A5-49CE-9DAE-2A0D-BEA459A59D88";
	setAttr ".ics" -type "componentList" 3 "vtx[82:83]" "vtx[309]" "vtx[311]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".d" 1e-006;
createNode polyTweak -n "polyTweak74";
	rename -uid "5901CD75-4F67-AAD4-6B42-F88232E36C33";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk";
	setAttr ".tk[82]" -type "float3" 0.0046393275 -0.051738739 -0.048945554 ;
	setAttr ".tk[83]" -type "float3" -0.0046393275 -0.051738739 -0.048945554 ;
	setAttr ".tk[309]" -type "float3" -0.0046393424 0.051738262 0.048945561 ;
	setAttr ".tk[311]" -type "float3" 0.0046393424 0.051738262 0.048945561 ;
createNode polyTweakUV -n "polyTweakUV3";
	rename -uid "69DB5EEA-47A7-93B9-A89F-E692A4261290";
	setAttr ".uopa" yes;
	setAttr -s 2 ".uvtk";
	setAttr ".uvtk[56]" -type "float2" -2.5818914e-010 0.028177058 ;
	setAttr ".uvtk[352]" -type "float2" 1.3433699e-014 -0.008098525 ;
createNode polyMergeVert -n "polyMergeVert3";
	rename -uid "215ECEDB-444B-9548-874A-49BAFCEF5740";
	setAttr ".ics" -type "componentList" 2 "vtx[50]" "vtx[309]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".d" 1e-006;
createNode polyTweak -n "polyTweak75";
	rename -uid "AD87ECA9-4DF9-CB59-1A04-A4A202A30789";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[50]" -type "float3" 4.4408921e-016 -0.056957722 -0.04735478 ;
	setAttr ".tk[309]" -type "float3" 0 0.056957245 0.04735478 ;
createNode polyTweakUV -n "polyTweakUV4";
	rename -uid "E58A372C-4D16-D8F1-FBA2-48A1A9374D97";
	setAttr ".uopa" yes;
	setAttr -s 2 ".uvtk";
	setAttr ".uvtk[123]" -type "float2" 3.3297032e-011 -0.011727526 ;
	setAttr ".uvtk[346]" -type "float2" 2.0514301e-010 -1.4677148e-013 ;
createNode polyMergeVert -n "polyMergeVert4";
	rename -uid "B083463E-4E85-7892-B309-66AFDC27C59B";
	setAttr ".ics" -type "componentList" 2 "vtx[96]" "vtx[307]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".d" 1e-006;
createNode polyTweak -n "polyTweak76";
	rename -uid "758FED87-43D9-F264-07A2-F3A75DBA4864";
	setAttr ".uopa" yes;
	setAttr -s 2 ".tk";
	setAttr ".tk[96]" -type "float3" -4.178925e-010 0.022790432 -0.022283256 ;
	setAttr ".tk[307]" -type "float3" 4.17892e-010 -0.022790909 0.022283241 ;
createNode polyTweakUV -n "polyTweakUV5";
	rename -uid "20B048B1-4902-84DB-3F14-9CB50325A062";
	setAttr ".uopa" yes;
	setAttr -s 5 ".uvtk";
	setAttr ".uvtk[64]" -type "float2" -0.001902687 -0.020682139 ;
	setAttr ".uvtk[69]" -type "float2" 0.001902681 -0.020682139 ;
	setAttr ".uvtk[347]" -type "float2" 0.0086357817 -0.0033179333 ;
	setAttr ".uvtk[349]" -type "float2" -0.0086357817 -0.0033179333 ;
createNode polyMergeVert -n "polyMergeVert5";
	rename -uid "27EC7198-44CA-AF20-1D66-2CB184A0E78B";
	setAttr ".ics" -type "componentList" 2 "vtx[84:85]" "vtx[306:307]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".d" 1e-006;
createNode polyTweak -n "polyTweak77";
	rename -uid "D26DAA54-4FE2-34FB-FE0A-818854E00260";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk";
	setAttr ".tk[84]" -type "float3" 0.0068472028 0.014810085 -0.043607369 ;
	setAttr ".tk[85]" -type "float3" -0.0068472028 0.014810085 -0.043607369 ;
	setAttr ".tk[306]" -type "float3" -0.0068472177 -0.014810562 0.043607369 ;
	setAttr ".tk[307]" -type "float3" 0.0068472177 -0.014810562 0.043607369 ;
createNode polySplitRing -n "polySplitRing13";
	rename -uid "CD308AE7-4494-E6B5-080C-81A5F6C4E1AD";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[600:607]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".wt" 0.60879272222518921;
	setAttr ".dr" no;
	setAttr ".re" 605;
	setAttr ".sma" 29.999999999999996;
	setAttr ".stp" 2;
	setAttr ".div" 1;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak78";
	rename -uid "B68560E5-4DB1-85FC-4194-B294709E0B48";
	setAttr ".uopa" yes;
	setAttr -s 97 ".tk[0:96]" -type "float3"  -2.7755576e-017 -0.14729725
		 0.047093801 2.7755576e-017 -0.14729725 0.047093801 -5.5511151e-017 -0.14846246 0.067207605
		 5.5511151e-017 -0.14846246 0.067207605 -5.5511151e-017 -0.13401332 0.067322664 5.5511151e-017
		 -0.13401332 0.067322664 -2.7755576e-017 -0.13673696 0.04733374 2.7755576e-017 -0.13673696
		 0.04733374 5.5511151e-017 -0.14795642 0.056974001 0 -0.15005685 0.069694035 -5.5511151e-017
		 -0.14081375 0.069641039 5.5511151e-017 -0.14081375 0.069641039 0 -0.13227187 0.069769762
		 -5.5511151e-017 -0.13230859 0.057584137 5.5511151e-017 -0.13230859 0.057584137 -5.5511151e-017
		 -0.1416714 0.044746984 5.5511151e-017 -0.1416714 0.044746984 0 -0.14807749 0.044930905
		 -5.5511151e-017 -0.14795642 0.056974001 0 -0.15102004 0.056706689 0 -0.14087816 0.073786318
		 0 -0.12919949 0.057768345 0 -0.14240962 0.040695272 1.110223e-016 -0.14062685 0.057615951
		 -1.110223e-016 -0.14062685 0.057615951 0 -0.14941044 0.050304271 -2.7755576e-017
		 -0.15038884 0.056574844 0 -0.1477246 0.045631759 2.7755576e-017 -0.14723548 0.050733641
		 2.7755576e-017 -0.15038884 0.056574844 0 -0.15091914 0.064217649 5.5511151e-017 -0.14797047
		 0.063403703 0 -0.14955522 0.068928227 -5.5511151e-017 -0.14797047 0.063403703 0 -0.14955522
		 0.068928227 -5.5511151e-017 -0.14481285 0.068779506 0 -0.14551909 0.072675124 0 -0.14086202
		 0.072747499 5.5511151e-017 -0.14481285 0.068779506 0 -0.14086202 0.072747499 0 -0.13620494
		 0.072819889 5.5511151e-017 -0.13678977 0.068904206 0 -0.13284735 0.068961687 -5.5511151e-017
		 -0.13678977 0.068904206 0 -0.13284735 0.068961687 -5.5511151e-017 -0.1327644 0.063540682
		 0 -0.12984945 0.064506941 0 -0.12999958 0.057686284 5.5511151e-017 -0.1327644 0.063540682
		 0 -0.12999958 0.057686284 0 -0.1319252 0.049280412 2.7755576e-017 -0.13598366 0.051170141
		 0 -0.13506725 0.045773413 -2.7755576e-017 -0.13598366 0.051170141 0 -0.13506725 0.045773413
		 -5.5511151e-017 -0.13871482 0.045633402 0 -0.14161922 0.041388948 5.5511151e-017
		 -0.13871482 0.045633402 0 -0.14161922 0.041388948 0 -0.14512353 0.041334487 5.5511151e-017
		 -0.14469212 0.045582142 -5.5511151e-017 -0.14469212 0.045582142 5.5511151e-017 -0.14175555
		 0.050161608 5.5511151e-017 -0.14493036 0.057471365 1.110223e-016 -0.1360753 0.057608984
		 1.110223e-016 -0.14073148 0.064349219 -5.5511151e-017 -0.14175555 0.050161608 -1.110223e-016
		 -0.1360753 0.057608984 -5.5511151e-017 -0.14493036 0.057471365 -1.110223e-016 -0.14073148
		 0.064349219 0 -0.1477246 0.045631759 -2.7755576e-017 -0.14723548 0.050733641 0 -0.14887466
		 0.050502025 0 -0.14887466 0.050502025 2.7755576e-017 -0.15019666 0.063675418 -2.7755576e-017
		 -0.15019666 0.063675418 0 -0.14518112 0.071702421 0 -0.14518112 0.071702421 0 -0.13651252
		 0.071837142 0 -0.13651252 0.071837142 0 -0.13057998 0.064031422 0 -0.13057998 0.064031422
		 0 -0.13282762 0.048537724 0 -0.13282762 0.048537724 0 -0.13741058 0.043232299 0 -0.13741058
		 0.043232299 0 -0.14489356 0.042419862 0 -0.14489356 0.042419862 5.5511151e-017 -0.14498942
		 0.050570764 5.5511151e-017 -0.13860965 0.050669916 1.110223e-016 -0.13638997 0.063953087
		 5.5511151e-017 -0.14481299 0.063822173 -5.5511151e-017 -0.13860965 0.050669916 -5.5511151e-017
		 -0.14498942 0.050570764 -5.5511151e-017 -0.14481299 0.063822173 -1.110223e-016 -0.13638997
		 0.063953087 0 -0.13783754 0.04225358;
createNode polyDelEdge -n "polyDelEdge1";
	rename -uid "A3EE6BFF-4D83-02EC-BB66-3FB8354A240A";
	setAttr ".ics" -type "componentList" 17 "e[108:109]" "e[112:113]" "e[116:117]" "e[120:121]" "e[140]" "e[143]" "e[146:147]" "e[150:151]" "e[153]" "e[156:157]" "e[160:161]" "e[164:165]" "e[168:169]" "e[172:173]" "e[176:177]" "e[180:181]" "e[184]";
	setAttr ".cv" yes;
createNode polyTweak -n "polyTweak79";
	rename -uid "42516E27-4357-DB1A-86E3-16BFCE35B06B";
	setAttr ".uopa" yes;
	setAttr -s 14 ".tk";
	setAttr ".tk[101]" -type "float3" 0 0 0.037252162 ;
	setAttr ".tk[102]" -type "float3" 0 0 0.037252162 ;
	setAttr ".tk[109]" -type "float3" 0 0 0.037252162 ;
	setAttr ".tk[303]" -type "float3" 0 -0.00076030777 -0.020131694 ;
	setAttr ".tk[304]" -type "float3" 0 0.012506583 -0.059835155 ;
	setAttr ".tk[305]" -type "float3" 0 -0.00076030777 -0.020131694 ;
	setAttr ".tk[306]" -type "float3" -0.018166902 0.033392418 -0.0010664124 ;
	setAttr ".tk[307]" -type "float3" -0.021093722 0.025196699 -0.016687077 ;
	setAttr ".tk[308]" -type "float3" -0.020229623 0.012843924 -0.032529268 ;
	setAttr ".tk[309]" -type "float3" 0 0.01001748 -0.038448751 ;
	setAttr ".tk[310]" -type "float3" 0.020229623 0.012843924 -0.032529268 ;
	setAttr ".tk[311]" -type "float3" 0.021093722 0.025196699 -0.016687077 ;
	setAttr ".tk[312]" -type "float3" 0.018166902 0.033392418 -0.0010664124 ;
	setAttr ".tk[313]" -type "float3" 0 0.03659289 0.0047403658 ;
createNode polySoftEdge -n "polySoftEdge1";
	rename -uid "E9897828-4267-688A-0FCE-05977A2C4053";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[*]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".a" 180;
createNode polyTweak -n "polyTweak80";
	rename -uid "E3521803-4438-5287-5167-8ABC575E70C2";
	setAttr ".uopa" yes;
	setAttr -s 76 ".tk";
	setAttr ".tk[0]" -type "float3" -0.0056440388 0.012016989 -0.14309496 ;
	setAttr ".tk[1]" -type "float3" 0.0056440388 0.012016989 -0.14309496 ;
	setAttr ".tk[2]" -type "float3" -0.011573167 0.074250944 -0.12308063 ;
	setAttr ".tk[3]" -type "float3" 0.011573167 0.074250944 -0.12308063 ;
	setAttr ".tk[4]" -type "float3" -0.010787183 0.091487579 -0.071791805 ;
	setAttr ".tk[5]" -type "float3" 0.010787183 0.091487579 -0.071791805 ;
	setAttr ".tk[6]" -type "float3" -0.0042302948 -0.0021943199 -0.040065791 ;
	setAttr ".tk[7]" -type "float3" 0.0042302948 -0.0021943199 -0.040065791 ;
	setAttr ".tk[8]" -type "float3" 0.017101025 0.042583082 -0.13208808 ;
	setAttr ".tk[9]" -type "float3" 0 0.081874326 -0.10096457 ;
	setAttr ".tk[10]" -type "float3" 0.024589844 0.029538227 -0.062198699 ;
	setAttr ".tk[11]" -type "float3" -0.024589846 0.029538227 -0.062198699 ;
	setAttr ".tk[12]" -type "float3" 0 0.077827983 -0.095850557 ;
	setAttr ".tk[13]" -type "float3" 0.0087194759 0.0059068091 -0.023624768 ;
	setAttr ".tk[14]" -type "float3" -0.0087194629 0.0059068091 -0.023624768 ;
	setAttr ".tk[15]" -type "float3" 0.022561077 0.058119141 -0.07158459 ;
	setAttr ".tk[16]" -type "float3" -0.022561084 0.058119141 -0.07158459 ;
	setAttr ".tk[17]" -type "float3" 0 0.0052812062 -0.13298315 ;
	setAttr ".tk[18]" -type "float3" -0.017101025 0.042583082 -0.13208808 ;
	setAttr ".tk[19]" -type "float3" 0 0.037084833 -0.090146743 ;
	setAttr ".tk[20]" -type "float3" 0 0.024782764 -0.071327455 ;
	setAttr ".tk[21]" -type "float3" 0 -0.10047227 -0.052009776 ;
	setAttr ".tk[22]" -type "float3" 0 0.062781505 -0.085047387 ;
	setAttr ".tk[23]" -type "float3" -0.027726958 0.043333534 -0.054746162 ;
	setAttr ".tk[24]" -type "float3" 0.027726958 0.043333534 -0.054746162 ;
	setAttr ".tk[25]" -type "float3" 0 -0.032270133 -0.096629322 ;
	setAttr ".tk[26]" -type "float3" 0.0079311682 0.035757672 -0.096371874 ;
	setAttr ".tk[27]" -type "float3" -0.0047095255 0.0074686725 -0.13761483 ;
	setAttr ".tk[28]" -type "float3" 0.0095094005 0.023292067 -0.14316456 ;
	setAttr ".tk[29]" -type "float3" -0.0079311682 0.035757672 -0.096371874 ;
	setAttr ".tk[30]" -type "float3" 0 0.10342375 -0.059985634 ;
	setAttr ".tk[31]" -type "float3" 0.017063677 0.06249439 -0.13054441 ;
	setAttr ".tk[32]" -type "float3" -0.003247652 0.079526864 -0.10791931 ;
	setAttr ".tk[33]" -type "float3" -0.017063677 0.06249439 -0.13054441 ;
	setAttr ".tk[34]" -type "float3" 0.003247652 0.079526864 -0.10791931 ;
	setAttr ".tk[35]" -type "float3" 0.019310666 0.025974533 -0.070683666 ;
	setAttr ".tk[36]" -type "float3" -0.019310666 0.025974533 -0.070683666 ;
	setAttr ".tk[37]" -type "float3" -0.0044507547 0.074006982 -0.088221997 ;
	setAttr ".tk[38]" -type "float3" 0.0044507547 0.074006982 -0.088221997 ;
	setAttr ".tk[39]" -type "float3" 0.0076668006 0.073890783 -0.054940678 ;
	setAttr ".tk[40]" -type "float3" 0 0.13079238 -0.063664302 ;
	setAttr ".tk[41]" -type "float3" -0.0059146984 -0.071711488 -0.035752639 ;
	setAttr ".tk[42]" -type "float3" -0.0076668006 0.073890783 -0.054940678 ;
	setAttr ".tk[43]" -type "float3" 0.0059146984 -0.071711488 -0.035752639 ;
	setAttr ".tk[44]" -type "float3" 0 0.0072596129 -0.10486429 ;
	setAttr ".tk[45]" -type "float3" 0.0070236241 0.01580248 -0.062166832 ;
	setAttr ".tk[46]" -type "float3" -0.0028505321 -0.0093703512 -0.063022062 ;
	setAttr ".tk[47]" -type "float3" -0.0070236241 0.01580248 -0.062166832 ;
	setAttr ".tk[48]" -type "float3" 0.0028505321 -0.0093703512 -0.063022062 ;
	setAttr ".tk[49]" -type "float3" 0.019153694 0.061971486 -0.069503523 ;
	setAttr ".tk[50]" -type "float3" -0.019153694 0.061971486 -0.069503523 ;
	setAttr ".tk[51]" -type "float3" -0.023799922 0.051907443 -0.074940369 ;
	setAttr ".tk[52]" -type "float3" -0.027769843 0.035609055 -0.058918975 ;
	setAttr ".tk[53]" -type "float3" 0.023799922 0.051907443 -0.074940369 ;
	setAttr ".tk[54]" -type "float3" 0.027769843 0.035609055 -0.058918975 ;
	setAttr ".tk[55]" -type "float3" 0.0047095255 0.0074686725 -0.13761483 ;
	setAttr ".tk[56]" -type "float3" -0.0095094005 0.023292067 -0.14316456 ;
	setAttr ".tk[57]" -type "float3" 0.0054147346 -0.019360293 -0.10040216 ;
	setAttr ".tk[58]" -type "float3" -0.0054147346 -0.019360293 -0.10040216 ;
	setAttr ".tk[59]" -type "float3" -0.0077986782 0.093698561 -0.075512476 ;
	setAttr ".tk[60]" -type "float3" 0.0077986782 0.093698561 -0.075512476 ;
	setAttr ".tk[61]" -type "float3" -0.0062300526 0.079422116 -0.05431078 ;
	setAttr ".tk[62]" -type "float3" 0.0062300526 0.079422116 -0.05431078 ;
	setAttr ".tk[63]" -type "float3" -0.005155785 0.0037205839 -0.092791177 ;
	setAttr ".tk[64]" -type "float3" 0.005155785 0.0037205839 -0.092791177 ;
	setAttr ".tk[65]" -type "float3" 0.0029197175 -0.021424858 -0.031800717 ;
	setAttr ".tk[66]" -type "float3" -0.0029197175 -0.021424858 -0.031800717 ;
	setAttr ".tk[67]" -type "float3" 0 -0.026033169 -0.026220657 ;
	setAttr ".tk[277]" -type "float3" -0.010473394 -0.0084370365 -0.035265349 ;
	setAttr ".tk[278]" -type "float3" -0.012270145 -0.013908664 0.0051561533 ;
	setAttr ".tk[279]" -type "float3" -0.011739677 -0.02513128 0.021663794 ;
	setAttr ".tk[280]" -type "float3" 0 -0.025769033 0.018209307 ;
	setAttr ".tk[281]" -type "float3" 0.011739677 -0.02513128 0.021663794 ;
	setAttr ".tk[282]" -type "float3" 0.012270145 -0.013908664 0.0051561533 ;
	setAttr ".tk[283]" -type "float3" 0.010473394 -0.0084370365 -0.035265349 ;
	setAttr ".tk[284]" -type "float3" 0 -0.0055293604 -0.072148718 ;
createNode polyNormalPerVertex -n "polyNormalPerVertex1";
	rename -uid "A6C39F1C-4ABA-F7C0-A3FD-8DAA2040F286";
	setAttr ".uopa" yes;
	setAttr -s 285 ".vn";
	setAttr ".vn[0].nxyz" -type "float3" -0.77943337 -0.41267544 0.47136268 ;
	setAttr ".vn[1].nxyz" -type "float3" 0.77943349 -0.4126755 0.47136211 ;
	setAttr ".vn[2].nxyz" -type "float3" -0.70766056 0.53654164 0.45971701 ;
	setAttr ".vn[3].nxyz" -type "float3" 0.7076602 0.53654158 0.45971769 ;
	setAttr ".vn[4].nxyz" -type "float3" -0.70380908 0.60916764 -0.36546901 ;
	setAttr ".vn[5].nxyz" -type "float3" 0.70380896 0.60916746 -0.36546943 ;
	setAttr ".vn[6].nxyz" -type "float3" -0.9046241 -0.32862633 -0.271404 ;
	setAttr ".vn[7].nxyz" -type "float3" 0.90462399 -0.32862625 -0.27140418 ;
	setAttr ".vn[8].nxyz" -type "float3" 0.81324601 -0.15342382 0.56133074 ;
	setAttr ".vn[9].nxyz" -type "float3" -5.1134492e-009 0.79640704 0.604761 ;
	setAttr ".vn[10].nxyz" -type "float3" -0.76141173 0.64801508 0.018133087 ;
	setAttr ".vn[11].nxyz" -type "float3" 0.76141173 0.64801502 0.018133301 ;
	setAttr ".vn[12].nxyz" -type "float3" 5.2604423e-009 0.85270303 -0.52239585 ;
	setAttr ".vn[13].nxyz" -type "float3" -0.82745868 -0.15608172 -0.53939837 ;
	setAttr ".vn[14].nxyz" -type "float3" 0.82745868 -0.15608169 -0.53939837 ;
	setAttr ".vn[15].nxyz" -type "float3" -0.91311908 -0.40766868 0.0044561266 ;
	setAttr ".vn[16].nxyz" -type "float3" 0.91311896 -0.40766877 0.004455592 ;
	setAttr ".vn[17].nxyz" -type "float3" 1.3800865e-008 -0.71712136 0.69694835 ;
	setAttr ".vn[18].nxyz" -type "float3" -0.81324595 -0.1534238 0.56133074 ;
	setAttr ".vn[19].nxyz" -type "float3" -4.4816741e-008 -0.14517199 0.98940641 ;
	setAttr ".vn[20].nxyz" -type "float3" 1.102126e-008 0.9999451 0.010478985 ;
	setAttr ".vn[21].nxyz" -type "float3" -3.1590968e-008 -0.046527691 -0.99891698 ;
	setAttr ".vn[22].nxyz" -type "float3" -3.9631654e-008 -0.90248603 0.4307192 ;
	setAttr ".vn[23].nxyz" -type "float3" 0.98394942 -0.16595948 -0.065582797 ;
	setAttr ".vn[24].nxyz" -type "float3" -0.9839493 -0.16595957 -0.065583304 ;
	setAttr ".vn[25].nxyz" -type "float3" -1.7981012e-008 -0.33415553 0.94251806 ;
	setAttr ".vn[26].nxyz" -type "float3" -0.41672394 -0.14874771 0.89678055 ;
	setAttr ".vn[27].nxyz" -type "float3" 0.35273641 -0.66646338 0.65681326 ;
	setAttr ".vn[28].nxyz" -type "float3" 0.82277292 -0.2869032 0.49064377 ;
	setAttr ".vn[29].nxyz" -type "float3" 0.41672397 -0.1487477 0.89678049 ;
	setAttr ".vn[30].nxyz" -type "float3" -3.9652832e-008 0.087078139 0.99620152 ;
	setAttr ".vn[31].nxyz" -type "float3" 0.81659007 0.096853003 0.56903446 ;
	setAttr ".vn[32].nxyz" -type "float3" 0.37673172 0.73410451 0.56494588 ;
	setAttr ".vn[33].nxyz" -type "float3" -0.81659037 0.09685313 0.56903398 ;
	setAttr ".vn[34].nxyz" -type "float3" -0.37673172 0.73410434 0.56494612 ;
	setAttr ".vn[35].nxyz" -type "float3" -0.34534714 0.9383195 0.017083272 ;
	setAttr ".vn[36].nxyz" -type "float3" 0.3453472 0.93831944 0.017083293 ;
	setAttr ".vn[37].nxyz" -type "float3" 0.36051336 0.78674585 -0.50106001 ;
	setAttr ".vn[38].nxyz" -type "float3" -0.36051312 0.78674585 -0.50106019 ;
	setAttr ".vn[39].nxyz" -type "float3" -0.82053655 0.10628402 -0.5616259 ;
	setAttr ".vn[40].nxyz" -type "float3" 1.5294102e-008 0.12639616 -0.99197984 ;
	setAttr ".vn[41].nxyz" -type "float3" -0.4454599 -0.096276939 -0.89011031 ;
	setAttr ".vn[42].nxyz" -type "float3" 0.82053614 0.10628406 -0.56162626 ;
	setAttr ".vn[43].nxyz" -type "float3" 0.44545951 -0.09627685 -0.89011037 ;
	setAttr ".vn[44].nxyz" -type "float3" 0 0.24519947 -0.96947271 ;
	setAttr ".vn[45].nxyz" -type "float3" 0.87326467 -0.31111002 -0.37499258 ;
	setAttr ".vn[46].nxyz" -type "float3" 0.99007726 -0.073422559 -0.11981732 ;
	setAttr ".vn[47].nxyz" -type "float3" -0.87326461 -0.31110996 -0.37499273 ;
	setAttr ".vn[48].nxyz" -type "float3" -0.99007732 -0.073422581 -0.11981683 ;
	setAttr ".vn[49].nxyz" -type "float3" -0.5517025 -0.79933417 0.23809522 ;
	setAttr ".vn[50].nxyz" -type "float3" 0.55170256 -0.79933411 0.23809507 ;
	setAttr ".vn[51].nxyz" -type "float3" 0.94413775 -0.32749057 -0.036794402 ;
	setAttr ".vn[52].nxyz" -type "float3" 0.99022698 0.1321061 -0.044706769 ;
	setAttr ".vn[53].nxyz" -type "float3" -0.94413775 -0.32749063 -0.036794595 ;
	setAttr ".vn[54].nxyz" -type "float3" -0.99022686 0.13210611 -0.044707242 ;
	setAttr ".vn[55].nxyz" -type "float3" -0.35273629 -0.66646314 0.65681362 ;
	setAttr ".vn[56].nxyz" -type "float3" -0.82277292 -0.28690326 0.49064383 ;
	setAttr ".vn[57].nxyz" -type "float3" -0.38048577 -0.31053314 0.87109113 ;
	setAttr ".vn[58].nxyz" -type "float3" 0.38048589 -0.31053311 0.87109107 ;
	setAttr ".vn[59].nxyz" -type "float3" 0.40602994 0.05431715 0.9122442 ;
	setAttr ".vn[60].nxyz" -type "float3" -0.40603 0.054317143 0.91224408 ;
	setAttr ".vn[61].nxyz" -type "float3" -0.34446153 0.075407162 -0.93576705 ;
	setAttr ".vn[62].nxyz" -type "float3" 0.34446153 0.075407259 -0.93576711 ;
	setAttr ".vn[63].nxyz" -type "float3" 0.69377542 0.12142316 -0.70988184 ;
	setAttr ".vn[64].nxyz" -type "float3" -0.69377548 0.12142279 -0.70988178 ;
	setAttr ".vn[65].nxyz" -type "float3" -0.83748478 -0.5163703 0.17883217 ;
	setAttr ".vn[66].nxyz" -type "float3" 0.83748484 -0.51637012 0.17883244 ;
	setAttr ".vn[67].nxyz" -type "float3" 3.7476454e-008 0.10358296 0.99462086 ;
	setAttr ".vn[68].nxyz" -type "float3" -0.69390488 -0.067597307 0.71688682 ;
	setAttr ".vn[69].nxyz" -type "float3" 0.69390488 -0.067597315 0.71688682 ;
	setAttr ".vn[70].nxyz" -type "float3" -0.26730683 0.33138084 0.90483904 ;
	setAttr ".vn[71].nxyz" -type "float3" 0.26730689 0.33138081 0.90483916 ;
	setAttr ".vn[72].nxyz" -type "float3" -0.26376852 0.43814954 -0.85933179 ;
	setAttr ".vn[73].nxyz" -type "float3" 0.26376846 0.43814954 -0.85933179 ;
	setAttr ".vn[74].nxyz" -type "float3" -0.58286726 -0.11028478 -0.80504847 ;
	setAttr ".vn[75].nxyz" -type "float3" 0.58286726 -0.11028479 -0.80504847 ;
	setAttr ".vn[76].nxyz" -type "float3" 0.58140206 -0.083664186 0.8093034 ;
	setAttr ".vn[77].nxyz" -type "float3" 1.5459696e-008 0.24829963 0.9686833 ;
	setAttr ".vn[78].nxyz" -type "float3" -0.3218886 0.94270903 0.087678231 ;
	setAttr ".vn[79].nxyz" -type "float3" 0.3218886 0.94270909 0.08767838 ;
	setAttr ".vn[80].nxyz" -type "float3" -8.4014351e-009 0.34555835 -0.93839729 ;
	setAttr ".vn[81].nxyz" -type "float3" -0.46998173 -0.031238113 -0.88212329 ;
	setAttr ".vn[82].nxyz" -type "float3" 0.46998173 -0.031238126 -0.88212329 ;
	setAttr ".vn[83].nxyz" -type "float3" 3.1549114e-008 -0.14181049 -0.98989391 ;
	setAttr ".vn[84].nxyz" -type "float3" -0.89417678 -0.098319232 -0.43678513 ;
	setAttr ".vn[85].nxyz" -type "float3" 0.89417678 -0.098319232 -0.43678513 ;
	setAttr ".vn[86].nxyz" -type "float3" 0 -0.12065285 0.9926948 ;
	setAttr ".vn[87].nxyz" -type "float3" -0.58140218 -0.083664201 0.80930328 ;
	setAttr ".vn[88].nxyz" -type "float3" 9.5149897e-009 -0.04277429 0.99908477 ;
	setAttr ".vn[89].nxyz" -type "float3" 1.1528398e-008 0.0078014121 -0.99996954 ;
	setAttr ".vn[90].nxyz" -type "float3" 0 -0.18604031 -0.98254216 ;
	setAttr ".vn[91].nxyz" -type "float3" 0.97616112 -0.21154699 -0.048553012 ;
	setAttr ".vn[92].nxyz" -type "float3" -0.97616118 -0.21154702 -0.048552953 ;
	setAttr ".vn[93].nxyz" -type "float3" 0.079298966 -0.56822765 -0.81904149 ;
	setAttr ".vn[94].nxyz" -type "float3" 0.034948241 -0.99938911 -0.00035996627 ;
	setAttr ".vn[95].nxyz" -type "float3" 0.071890235 0.58766353 -0.80590534 ;
	setAttr ".vn[96].nxyz" -type "float3" 0.015227772 0.99956268 0.025351489 ;
	setAttr ".vn[97].nxyz" -type "float3" 0.076882623 -0.58005428 0.81094158 ;
	setAttr ".vn[98].nxyz" -type "float3" 0.057281461 0.59541208 0.80137599 ;
	setAttr ".vn[99].nxyz" -type "float3" -0.076882623 -0.58005428 0.81094158 ;
	setAttr ".vn[100].nxyz" -type "float3" -0.034948237 -0.99938905 -0.00035997891 ;
	setAttr ".vn[101].nxyz" -type "float3" -0.057281461 0.59541208 0.80137599 ;
	setAttr ".vn[102].nxyz" -type "float3" -0.01522777 0.99956268 0.025351495 ;
	setAttr ".vn[103].nxyz" -type "float3" -0.079298973 -0.56822765 -0.81904149 ;
	setAttr ".vn[104].nxyz" -type "float3" -0.071890235 0.58766353 -0.80590534 ;
	setAttr ".vn[105].nxyz" -type "float3" 0.076524481 -0.61489224 -0.78488952 ;
	setAttr ".vn[106].nxyz" -type "float3" 0.12083501 -0.99267256 -0.0004176842 ;
	setAttr ".vn[107].nxyz" -type "float3" -0.0032100871 0.55454153 -0.83214986 ;
	setAttr ".vn[108].nxyz" -type "float3" -0.0041728839 0.9999913 -3.2834618e-005 ;
	setAttr ".vn[109].nxyz" -type "float3" 0.076458856 -0.61532372 0.78455764 ;
	setAttr ".vn[110].nxyz" -type "float3" -0.003244716 0.55459619 0.83211327 ;
	setAttr ".vn[111].nxyz" -type "float3" -0.076458916 -0.61532402 0.78455746 ;
	setAttr ".vn[112].nxyz" -type "float3" -0.12083501 -0.99267256 -0.00041769317 ;
	setAttr ".vn[113].nxyz" -type "float3" 0.003244702 0.55459648 0.83211315 ;
	setAttr ".vn[114].nxyz" -type "float3" 0.0041728839 0.99999136 -3.2817126e-005 ;
	setAttr ".vn[115].nxyz" -type "float3" -0.076524422 -0.61489201 -0.7848897 ;
	setAttr ".vn[116].nxyz" -type "float3" 0.0032101246 0.55454129 -0.83215004 ;
	setAttr ".vn[117].nxyz" -type "float3" 0.061835032 -0.64439535 -0.76218832 ;
	setAttr ".vn[118].nxyz" -type "float3" 0.11964475 -0.99281675 -0.00018102161 ;
	setAttr ".vn[119].nxyz" -type "float3" -0.0087043811 0.61333269 -0.78977674 ;
	setAttr ".vn[120].nxyz" -type "float3" 0.010655079 0.99994266 0.0011151289 ;
	setAttr ".vn[121].nxyz" -type "float3" 0.061731674 -0.64327276 0.76314449 ;
	setAttr ".vn[122].nxyz" -type "float3" -0.0084842155 0.61191505 0.790878 ;
	setAttr ".vn[123].nxyz" -type "float3" -0.061731715 -0.643273 0.7631442 ;
	setAttr ".vn[124].nxyz" -type "float3" -0.11964475 -0.99281681 -0.00018102667 ;
	setAttr ".vn[125].nxyz" -type "float3" 0.0084842006 0.61191529 0.79087782 ;
	setAttr ".vn[126].nxyz" -type "float3" -0.010655087 0.99994266 0.0011151199 ;
	setAttr ".vn[127].nxyz" -type "float3" -0.06183495 -0.64439493 -0.76218867 ;
	setAttr ".vn[128].nxyz" -type "float3" 0.0087043988 0.61333251 -0.78977692 ;
	setAttr ".vn[129].nxyz" -type "float3" 0.052015323 -0.78150636 -0.6217252 ;
	setAttr ".vn[130].nxyz" -type "float3" 0.064691849 -0.99790519 -0.00031385338 ;
	setAttr ".vn[131].nxyz" -type "float3" -0.012312327 0.67313278 -0.73941916 ;
	setAttr ".vn[132].nxyz" -type "float3" 0.013787731 0.99990493 -9.5581832e-005 ;
	setAttr ".vn[133].nxyz" -type "float3" -0.25701624 -0.79683107 0.54681176 ;
	setAttr ".vn[134].nxyz" -type "float3" -0.23164342 0.72260666 0.65129185 ;
	setAttr ".vn[135].nxyz" -type "float3" 0.25701618 -0.79683107 0.5468117 ;
	setAttr ".vn[136].nxyz" -type "float3" -0.064691834 -0.99790519 -0.00031385882 ;
	setAttr ".vn[137].nxyz" -type "float3" 0.23164342 0.72260672 0.65129179 ;
	setAttr ".vn[138].nxyz" -type "float3" -0.013787759 0.99990493 -9.5573909e-005 ;
	setAttr ".vn[139].nxyz" -type "float3" -0.052015316 -0.78150636 -0.6217252 ;
	setAttr ".vn[140].nxyz" -type "float3" 0.01231228 0.67313272 -0.73941916 ;
	setAttr ".vn[141].nxyz" -type "float3" 0.015685199 -0.72646296 -0.68702668 ;
	setAttr ".vn[142].nxyz" -type "float3" 0.053466413 -0.99855787 -0.0048613674 ;
	setAttr ".vn[143].nxyz" -type "float3" 0.12627989 0.77069569 -0.62456518 ;
	setAttr ".vn[144].nxyz" -type "float3" 0.1942776 0.98089457 -0.010099146 ;
	setAttr ".vn[145].nxyz" -type "float3" 0.16261552 -0.9866088 0.012623357 ;
	setAttr ".vn[146].nxyz" -type "float3" 0.18193263 0.9576028 0.22337762 ;
	setAttr ".vn[147].nxyz" -type "float3" -0.1626154 -0.9866088 0.012623471 ;
	setAttr ".vn[148].nxyz" -type "float3" -0.053466246 -0.99855781 -0.0048615821 ;
	setAttr ".vn[149].nxyz" -type "float3" -0.18193257 0.95760292 0.22337714 ;
	setAttr ".vn[150].nxyz" -type "float3" -0.19427745 0.98089468 -0.010099109 ;
	setAttr ".vn[151].nxyz" -type "float3" -0.015684998 -0.72646284 -0.6870268 ;
	setAttr ".vn[152].nxyz" -type "float3" -0.12627973 0.77069581 -0.62456506 ;
	setAttr ".vn[153].nxyz" -type "float3" -0.03661624 -0.70101434 -0.7122066 ;
	setAttr ".vn[154].nxyz" -type "float3" -0.010219132 -0.70704305 0.70709664 ;
	setAttr ".vn[155].nxyz" -type "float3" 0.5115 0.67150867 -0.536138 ;
	setAttr ".vn[156].nxyz" -type "float3" 0.55101824 0.63247573 0.54438347 ;
	setAttr ".vn[157].nxyz" -type "float3" -0.034266546 -0.70421654 -0.70915788 ;
	setAttr ".vn[158].nxyz" -type "float3" -0.030215038 -0.70564204 0.70792407 ;
	setAttr ".vn[159].nxyz" -type "float3" 0.5268383 0.6661129 -0.52795374 ;
	setAttr ".vn[160].nxyz" -type "float3" 0.50604612 0.68615013 0.52260447 ;
	setAttr ".vn[161].nxyz" -type "float3" 0.030215273 -0.70564204 0.70792395 ;
	setAttr ".vn[162].nxyz" -type "float3" 0.034266848 -0.70421684 -0.70915759 ;
	setAttr ".vn[163].nxyz" -type "float3" -0.50604594 0.68615055 0.52260405 ;
	setAttr ".vn[164].nxyz" -type "float3" -0.5268383 0.66611344 -0.52795309 ;
	setAttr ".vn[165].nxyz" -type "float3" 0.010219395 -0.70704389 0.70709586 ;
	setAttr ".vn[166].nxyz" -type "float3" 0.036616679 -0.70101434 -0.7122066 ;
	setAttr ".vn[167].nxyz" -type "float3" -0.55101818 0.63247597 0.54438323 ;
	setAttr ".vn[168].nxyz" -type "float3" -0.5114997 0.67150885 -0.53613806 ;
	setAttr ".vn[169].nxyz" -type "float3" -0.39335197 -0.52220112 0.75669032 ;
	setAttr ".vn[170].nxyz" -type "float3" -0.32466605 0.56259602 0.76031423 ;
	setAttr ".vn[171].nxyz" -type "float3" 0.18887094 -0.90679765 -0.37688968 ;
	setAttr ".vn[172].nxyz" -type "float3" 0.39052871 0.91088837 -0.13330343 ;
	setAttr ".vn[173].nxyz" -type "float3" 0.39335188 -0.52220112 0.75669038 ;
	setAttr ".vn[174].nxyz" -type "float3" 0.32466611 0.56259632 0.76031405 ;
	setAttr ".vn[175].nxyz" -type "float3" -0.39052835 0.91088837 -0.13330425 ;
	setAttr ".vn[176].nxyz" -type "float3" -0.18887086 -0.90679777 -0.37688947 ;
	setAttr ".vn[177].nxyz" -type "float3" 0.28015265 -0.21364492 -0.93587941 ;
	setAttr ".vn[178].nxyz" -type "float3" -0.25673214 -0.77051234 0.5834375 ;
	setAttr ".vn[179].nxyz" -type "float3" 0.28015265 -0.21364492 -0.93587941 ;
	setAttr ".vn[180].nxyz" -type "float3" 0.64038438 0.40642685 0.65170944 ;
	setAttr ".vn[181].nxyz" -type "float3" -0.29717615 -0.78092313 -0.5494045 ;
	setAttr ".vn[182].nxyz" -type "float3" 0.34011683 -0.28712299 0.89547807 ;
	setAttr ".vn[183].nxyz" -type "float3" 0.6746887 0.39087433 -0.62610906 ;
	setAttr ".vn[184].nxyz" -type "float3" 0.34011683 -0.28712299 0.89547807 ;
	setAttr ".vn[185].nxyz" -type "float3" -0.34011644 -0.28712279 0.89547837 ;
	setAttr ".vn[186].nxyz" -type "float3" 0.29717654 -0.78092355 -0.54940391 ;
	setAttr ".vn[187].nxyz" -type "float3" -0.34011644 -0.28712279 0.89547837 ;
	setAttr ".vn[188].nxyz" -type "float3" -0.67468899 0.39087504 -0.62610829 ;
	setAttr ".vn[189].nxyz" -type "float3" 0.25673217 -0.770513 0.58343661 ;
	setAttr ".vn[190].nxyz" -type "float3" -0.28015265 -0.21364582 -0.93587923 ;
	setAttr ".vn[191].nxyz" -type "float3" -0.64038479 0.40642613 0.6517095 ;
	setAttr ".vn[192].nxyz" -type "float3" -0.28015265 -0.21364582 -0.93587923 ;
	setAttr ".vn[193].nxyz" -type "float3" 0.38275194 -0.080970742 0.92029595 ;
	setAttr ".vn[194].nxyz" -type "float3" 0.38275194 -0.080970742 0.92029595 ;
	setAttr ".vn[195].nxyz" -type "float3" 0.50504053 -0.19499706 -0.84077942 ;
	setAttr ".vn[196].nxyz" -type "float3" 0.50504053 -0.19499706 -0.84077942 ;
	setAttr ".vn[197].nxyz" -type "float3" -0.38275173 -0.080970749 0.92029607 ;
	setAttr ".vn[198].nxyz" -type "float3" -0.38275173 -0.080970749 0.92029607 ;
	setAttr ".vn[199].nxyz" -type "float3" -0.50504065 -0.19499713 -0.84077936 ;
	setAttr ".vn[200].nxyz" -type "float3" -0.50504065 -0.19499713 -0.84077936 ;
	setAttr ".vn[201].nxyz" -type "float3" 0.77101672 -0.061186418 -0.63386858 ;
	setAttr ".vn[202].nxyz" -type "float3" -0.78714335 -0.044324707 -0.61517549 ;
	setAttr ".vn[203].nxyz" -type "float3" 0.7866776 -0.1215435 0.60528147 ;
	setAttr ".vn[204].nxyz" -type "float3" -0.81733239 -0.097845703 0.5677976 ;
	setAttr ".vn[205].nxyz" -type "float3" 0.78714347 -0.044324674 -0.61517531 ;
	setAttr ".vn[206].nxyz" -type "float3" -0.7710169 -0.061186519 -0.63386852 ;
	setAttr ".vn[207].nxyz" -type "float3" 0.81733251 -0.097845271 0.56779736 ;
	setAttr ".vn[208].nxyz" -type "float3" -0.7866776 -0.12154319 0.60528141 ;
	setAttr ".vn[209].nxyz" -type "float3" -0.15038885 -0.51294142 0.84514749 ;
	setAttr ".vn[210].nxyz" -type "float3" -0.11635563 0.57501155 0.80982906 ;
	setAttr ".vn[211].nxyz" -type "float3" -0.073490843 0.99653131 0.039044365 ;
	setAttr ".vn[212].nxyz" -type "float3" -0.1267699 0.54916722 -0.8260417 ;
	setAttr ".vn[213].nxyz" -type "float3" -0.12253409 -0.48372924 -0.86659765 ;
	setAttr ".vn[214].nxyz" -type "float3" -0.074854717 -0.99716479 -0.0076960376 ;
	setAttr ".vn[215].nxyz" -type "float3" 0.12253405 -0.48372918 -0.86659765 ;
	setAttr ".vn[216].nxyz" -type "float3" 0.12676987 0.54916722 -0.8260417 ;
	setAttr ".vn[217].nxyz" -type "float3" 0.073490828 0.99653137 0.039044444 ;
	setAttr ".vn[218].nxyz" -type "float3" 0.11635559 0.57501149 0.80982906 ;
	setAttr ".vn[219].nxyz" -type "float3" 0.15038888 -0.51294142 0.84514749 ;
	setAttr ".vn[220].nxyz" -type "float3" 0.074854709 -0.99716473 -0.0076961294 ;
	setAttr ".vn[221].nxyz" -type "float3" 0.81063485 0.0054545272 -0.58552665 ;
	setAttr ".vn[222].nxyz" -type "float3" -0.79671919 0.014928997 -0.60416538 ;
	setAttr ".vn[223].nxyz" -type "float3" 0.80595946 0.02934582 0.59124303 ;
	setAttr ".vn[224].nxyz" -type "float3" -0.81835526 0.041448701 0.57321602 ;
	setAttr ".vn[225].nxyz" -type "float3" 0.79671925 0.014928967 -0.60416526 ;
	setAttr ".vn[226].nxyz" -type "float3" -0.81063485 0.0054545072 -0.58552665 ;
	setAttr ".vn[227].nxyz" -type "float3" 0.81835538 0.041448735 0.57321602 ;
	setAttr ".vn[228].nxyz" -type "float3" -0.80595958 0.02934581 0.59124285 ;
	setAttr ".vn[229].nxyz" -type "float3" 0.8682307 0.31358525 -0.38449955 ;
	setAttr ".vn[230].nxyz" -type "float3" -0.86728948 0.31286323 -0.3872022 ;
	setAttr ".vn[231].nxyz" -type "float3" 0.74799407 0.57579017 0.33010679 ;
	setAttr ".vn[232].nxyz" -type "float3" -0.77866548 0.54575944 0.30955896 ;
	setAttr ".vn[233].nxyz" -type "float3" 0.86728948 0.31286314 -0.38720223 ;
	setAttr ".vn[234].nxyz" -type "float3" -0.8682307 0.31358501 -0.38449952 ;
	setAttr ".vn[235].nxyz" -type "float3" 0.7786653 0.54575974 0.30955887 ;
	setAttr ".vn[236].nxyz" -type "float3" -0.74799418 0.57579023 0.33010668 ;
	setAttr ".vn[237].nxyz" -type "float3" 0.88446343 0.12763713 -0.44881302 ;
	setAttr ".vn[238].nxyz" -type "float3" -0.85950261 0.095984824 -0.50203818 ;
	setAttr ".vn[239].nxyz" -type "float3" 0.68699598 0.50900394 0.51860535 ;
	setAttr ".vn[240].nxyz" -type "float3" -0.74345112 0.42245582 0.51847035 ;
	setAttr ".vn[241].nxyz" -type "float3" 0.85950261 0.095984876 -0.50203806 ;
	setAttr ".vn[242].nxyz" -type "float3" -0.88446355 0.1276374 -0.44881293 ;
	setAttr ".vn[243].nxyz" -type "float3" 0.7434507 0.42245641 0.51847047 ;
	setAttr ".vn[244].nxyz" -type "float3" -0.68699569 0.50900465 0.51860517 ;
	setAttr ".vn[245].nxyz" -type "float3" 0.18721172 -0.98021412 -0.064281493 ;
	setAttr ".vn[246].nxyz" -type "float3" -0.32947087 -0.93538272 -0.12848455 ;
	setAttr ".vn[247].nxyz" -type "float3" 0.19232026 -0.97876453 0.070942737 ;
	setAttr ".vn[248].nxyz" -type "float3" -0.3116414 -0.94384384 0.10972057 ;
	setAttr ".vn[249].nxyz" -type "float3" 0.32947084 -0.93538272 -0.12848447 ;
	setAttr ".vn[250].nxyz" -type "float3" -0.18721169 -0.98021412 -0.064281464 ;
	setAttr ".vn[251].nxyz" -type "float3" 0.31164145 -0.94384378 0.10972051 ;
	setAttr ".vn[252].nxyz" -type "float3" -0.19232029 -0.97876453 0.070942737 ;
	setAttr ".vn[253].nxyz" -type "float3" -0.77656245 -0.029951407 0.62932795 ;
	setAttr ".vn[254].nxyz" -type "float3" 0.73104197 -0.1206767 0.67157638 ;
	setAttr ".vn[255].nxyz" -type "float3" 0.66121966 -0.14692225 -0.73566467 ;
	setAttr ".vn[256].nxyz" -type "float3" -0.8108958 -0.047222324 -0.58328211 ;
	setAttr ".vn[257].nxyz" -type "float3" -0.73104191 -0.1206768 0.67157638 ;
	setAttr ".vn[258].nxyz" -type "float3" 0.77656245 -0.029951505 0.62932801 ;
	setAttr ".vn[259].nxyz" -type "float3" 0.81089586 -0.04722229 -0.58328211 ;
	setAttr ".vn[260].nxyz" -type "float3" -0.6612196 -0.1469222 -0.73566467 ;
	setAttr ".vn[261].nxyz" -type "float3" 0.79116529 -0.093783006 0.60436934 ;
	setAttr ".vn[262].nxyz" -type "float3" 0.78659278 -0.069648705 -0.61353147 ;
	setAttr ".vn[263].nxyz" -type "float3" -0.79536724 -0.056553084 -0.60348386 ;
	setAttr ".vn[264].nxyz" -type "float3" -0.77966028 -0.084090993 0.62053084 ;
	setAttr ".vn[265].nxyz" -type "float3" -0.79116535 -0.093782999 0.60436934 ;
	setAttr ".vn[266].nxyz" -type "float3" 0.77966022 -0.084091023 0.6205309 ;
	setAttr ".vn[267].nxyz" -type "float3" 0.79536718 -0.056553137 -0.60348386 ;
	setAttr ".vn[268].nxyz" -type "float3" -0.78659284 -0.069648698 -0.61353153 ;
	setAttr ".vn[269].nxyz" -type "float3" -0.24875422 0.82669991 0.50466686 ;
	setAttr ".vn[270].nxyz" -type "float3" 3.7476454e-008 0.10358296 0.99462086 ;
	setAttr ".vn[271].nxyz" -type "float3" -0.37516931 0.91891432 0.12183844 ;
	setAttr ".vn[272].nxyz" -type "float3" 0.24875419 0.82669991 0.50466686 ;
	setAttr ".vn[273].nxyz" -type "float3" 0.37516925 0.91891426 0.12183843 ;
	setAttr ".vn[274].nxyz" -type "float3" 0.2429637 0.90844858 -0.3401323 ;
	setAttr ".vn[275].nxyz" -type "float3" 6.6014376e-009 0.86532688 -0.50120795 ;
	setAttr ".vn[276].nxyz" -type "float3" -0.2429637 0.90844858 -0.3401323 ;
	setAttr ".vn[277].nxyz" -type "float3" 0.49499768 0.76229399 -0.41699538 ;
	setAttr ".vn[278].nxyz" -type "float3" 0.69616324 0.68161881 0.22528365 ;
	setAttr ".vn[279].nxyz" -type "float3" 0.48773062 0.68462569 0.5416702 ;
	setAttr ".vn[280].nxyz" -type "float3" 3.7476454e-008 0.10358296 0.99462086 ;
	setAttr ".vn[281].nxyz" -type "float3" -0.48773062 0.68462574 0.54167014 ;
	setAttr ".vn[282].nxyz" -type "float3" -0.69616312 0.68161875 0.22528383 ;
	setAttr ".vn[283].nxyz" -type "float3" -0.49499774 0.76229393 -0.41699553 ;
	setAttr ".vn[284].nxyz" -type "float3" 3.5928622e-008 0.75862432 -0.6515283 ;
createNode animCurveTL -n "camera1_translateX";
	rename -uid "EFF937BD-41EC-F6BF-BCCB-979DDC3205F1";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  1 -0.074690097001796407 120 0.66775731459684762;
createNode animCurveTL -n "camera1_translateY";
	rename -uid "4F6C6CA5-432B-D63E-FC70-189B195D1C10";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  1 5.3754622544391371 120 8.3516806677468427;
createNode animCurveTL -n "camera1_translateZ";
	rename -uid "5A637876-412E-3CBA-BE82-7EAF1AE6C580";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  1 17.657382185602746 120 22.6821245683672;
createNode animCurveTU -n "camera1_visibility";
	rename -uid "49215529-43A2-AB14-27C8-6C944F780846";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr ".ktv[0]"  1 1;
	setAttr ".kot[0]"  5;
createNode animCurveTA -n "camera1_rotateX";
	rename -uid "BCEDBD4E-4BD8-8853-10B8-1C92C688AA99";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  1 -16.200000000000188 120 -20.400000000000453;
createNode animCurveTA -n "camera1_rotateY";
	rename -uid "FF9D2566-4C1C-5B5B-0AFC-EBB8D7B27A2D";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  1 -4.006052985522391e-016 120 -345.59999999995125;
createNode animCurveTA -n "camera1_rotateZ";
	rename -uid "24F77091-42BF-788D-A9DC-66A35D572EB6";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr ".ktv[0]"  1 6.8176281811633306e-018;
createNode animCurveTU -n "camera1_scaleX";
	rename -uid "104CD573-49FC-01E2-6ED9-57973D1FADE0";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr ".ktv[0]"  1 1;
createNode animCurveTU -n "camera1_scaleY";
	rename -uid "F906C6FB-4E43-654E-ACDF-FA8354712244";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr ".ktv[0]"  1 1;
createNode animCurveTU -n "camera1_scaleZ";
	rename -uid "DA162B46-4994-9C1F-E268-B7AB6F88F527";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr ".ktv[0]"  1 1;
createNode polyExtrudeFace -n "polyExtrudeFace48";
	rename -uid "E9CA49AE-4C6D-65A4-D6EA-C79995B3E262";
	setAttr ".ics" -type "componentList" 2 "f[8:9]" "f[12:13]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 5.6318464 0.58159238 ;
	setAttr ".rs" 43653;
	setAttr ".lt" -type "double3" 8.6736173798840355e-019 -1.1527237497865883e-015 -0.029624750315641681 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.31213679909706116 5.438169002532959 0.4960741400718689 ;
	setAttr ".cbx" -type "double3" 0.31213679909706116 5.8255243301391602 0.6671106219291687 ;
createNode polyTweak -n "polyTweak81";
	rename -uid "83B36E2E-4F5E-6131-2BFE-6C8DB44D831E";
	setAttr ".uopa" yes;
	setAttr -s 81 ".tk";
	setAttr ".tk[0]" -type "float3" 0 -0.032232519 0 ;
	setAttr ".tk[1]" -type "float3" 0 -0.032232519 0 ;
	setAttr ".tk[2]" -type "float3" 0 0.031050321 0 ;
	setAttr ".tk[3]" -type "float3" 0 0.031050321 0 ;
	setAttr ".tk[4]" -type "float3" 0 0.03356494 0 ;
	setAttr ".tk[5]" -type "float3" 0 0.03356494 0 ;
	setAttr ".tk[6]" -type "float3" 0 -0.032340724 0 ;
	setAttr ".tk[7]" -type "float3" 0 -0.032340724 0 ;
	setAttr ".tk[8]" -type "float3" 0 0.051774014 0 ;
	setAttr ".tk[9]" -type "float3" 0 0.038802184 0 ;
	setAttr ".tk[10]" -type "float3" 0 0.034389451 0 ;
	setAttr ".tk[11]" -type "float3" 0 0.034389451 0 ;
	setAttr ".tk[12]" -type "float3" 0 0.039452422 0 ;
	setAttr ".tk[13]" -type "float3" 0 0.036931727 0 ;
	setAttr ".tk[14]" -type "float3" 0 0.036931727 0 ;
	setAttr ".tk[15]" -type "float3" 0 -0.034606084 0 ;
	setAttr ".tk[16]" -type "float3" 0 -0.034606084 0 ;
	setAttr ".tk[17]" -type "float3" 0 -0.039081823 0 ;
	setAttr ".tk[18]" -type "float3" 0 0.051774014 0 ;
	setAttr ".tk[19]" -type "float3" 0 -0.083778031 0 ;
	setAttr ".tk[20]" -type "float3" 0 0.045869481 0 ;
	setAttr ".tk[21]" -type "float3" 0 0.039532296 0 ;
	setAttr ".tk[22]" -type "float3" 0 -0.045861557 0 ;
	setAttr ".tk[23]" -type "float3" 0 0.057274222 0 ;
	setAttr ".tk[24]" -type "float3" 0 0.057274222 0 ;
	setAttr ".tk[25]" -type "float3" 0 -0.027059024 0 ;
	setAttr ".tk[26]" -type "float3" 0 -0.015006732 0 ;
	setAttr ".tk[27]" -type "float3" 0 -0.036857452 0 ;
	setAttr ".tk[28]" -type "float3" 0 -0.020767353 0 ;
	setAttr ".tk[29]" -type "float3" 0 -0.015006732 0 ;
	setAttr ".tk[30]" -type "float3" 0 -0.004442757 0 ;
	setAttr ".tk[31]" -type "float3" 0 -0.031667981 0 ;
	setAttr ".tk[32]" -type "float3" 0 0.036415152 0 ;
	setAttr ".tk[33]" -type "float3" 0 -0.031667981 0 ;
	setAttr ".tk[34]" -type "float3" 0 0.036415152 0 ;
	setAttr ".tk[35]" -type "float3" 0 0.042992562 0 ;
	setAttr ".tk[36]" -type "float3" 0 0.042992562 0 ;
	setAttr ".tk[37]" -type "float3" 0 0.036764331 0 ;
	setAttr ".tk[38]" -type "float3" 0 0.036764331 0 ;
	setAttr ".tk[39]" -type "float3" 0 -0.020664778 0 ;
	setAttr ".tk[40]" -type "float3" 0 -0.045081068 0 ;
	setAttr ".tk[41]" -type "float3" 0 0.033863042 0 ;
	setAttr ".tk[42]" -type "float3" 0 -0.020664778 0 ;
	setAttr ".tk[43]" -type "float3" 0 0.033863042 0 ;
	setAttr ".tk[44]" -type "float3" 0 -0.025689827 0 ;
	setAttr ".tk[45]" -type "float3" 0 -0.019679887 0 ;
	setAttr ".tk[46]" -type "float3" 0 -0.03738907 0 ;
	setAttr ".tk[47]" -type "float3" 0 -0.019679887 0 ;
	setAttr ".tk[48]" -type "float3" 0 -0.03738907 0 ;
	setAttr ".tk[49]" -type "float3" 0 -0.043905936 0 ;
	setAttr ".tk[50]" -type "float3" 0 -0.043905936 0 ;
	setAttr ".tk[51]" -type "float3" 0 -0.019610779 0 ;
	setAttr ".tk[52]" -type "float3" 0 -0.053488649 0 ;
	setAttr ".tk[53]" -type "float3" 0 -0.019610779 0 ;
	setAttr ".tk[54]" -type "float3" 0 -0.053488649 0 ;
	setAttr ".tk[55]" -type "float3" 0 -0.036857452 0 ;
	setAttr ".tk[56]" -type "float3" 0 -0.020767353 0 ;
	setAttr ".tk[57]" -type "float3" 0 -0.025314322 0 ;
	setAttr ".tk[58]" -type "float3" 0 -0.025314322 0 ;
	setAttr ".tk[59]" -type "float3" 0 -0.019001668 0 ;
	setAttr ".tk[60]" -type "float3" 0 -0.019001668 0 ;
	setAttr ".tk[61]" -type "float3" 0 -0.010351102 0 ;
	setAttr ".tk[62]" -type "float3" 0 -0.010351102 0 ;
	setAttr ".tk[63]" -type "float3" 0 -0.028179539 0 ;
	setAttr ".tk[64]" -type "float3" 0 -0.028179539 0 ;
	setAttr ".tk[65]" -type "float3" 0 -0.045869481 0 ;
	setAttr ".tk[66]" -type "float3" 0 -0.045869481 0 ;
	setAttr ".tk[68]" -type "float3" -0.021337736 -0.056096178 -0.00051319785 ;
	setAttr ".tk[69]" -type "float3" 0.021337736 -0.056096178 -0.00051319785 ;
	setAttr ".tk[76]" -type "float3" -0.023504898 0 -0.05588311 ;
	setAttr ".tk[77]" -type "float3" 0 -0.00026527597 -0.065317623 ;
	setAttr ".tk[84]" -type "float3" -0.026791397 -0.044709355 -0.026692634 ;
	setAttr ".tk[85]" -type "float3" 0.026791397 -0.044709355 -0.026692634 ;
	setAttr ".tk[86]" -type "float3" 0 0.18726188 0.026692631 ;
	setAttr ".tk[87]" -type "float3" 0.023504898 0 -0.05588311 ;
	setAttr ".tk[88]" -type "float3" 0 0.00026527504 -0.044035405 ;
	setAttr ".tk[277]" -type "float3" 0 -0.035951365 0 ;
	setAttr ".tk[278]" -type "float3" 0 -0.040766753 0 ;
	setAttr ".tk[282]" -type "float3" 0 -0.040766753 0 ;
	setAttr ".tk[283]" -type "float3" 0 -0.035951365 0 ;
	setAttr ".tk[284]" -type "float3" 0 -0.034002081 0 ;
select -ne :time1;
	setAttr ".o" 120;
	setAttr ".unw" 120;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 4 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :initialShadingGroup;
	setAttr -s 9 ".dsm";
	setAttr ".ro" yes;
	setAttr -s 9 ".gn";
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "groupId3.id" "pCylinderShape1.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pCylinderShape1.iog.og[0].gco";
connectAttr "groupParts2.og" "pCylinderShape1.i";
connectAttr "groupId4.id" "pCylinderShape1.ciog.cog[0].cgid";
connectAttr "groupId1.id" "pSphereShape1.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pSphereShape1.iog.og[0].gco";
connectAttr "groupParts1.og" "pSphereShape1.i";
connectAttr "groupId2.id" "pSphereShape1.ciog.cog[0].cgid";
connectAttr "groupParts4.og" "pCubeShape1.i";
connectAttr "groupId7.id" "pCubeShape1.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pCubeShape1.iog.og[0].gco";
connectAttr "groupId8.id" "pCubeShape1.ciog.cog[0].cgid";
connectAttr "groupId5.id" "pCubeShape2.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pCubeShape2.iog.og[0].gco";
connectAttr "groupParts3.og" "pCubeShape2.i";
connectAttr "groupId6.id" "pCubeShape2.ciog.cog[0].cgid";
connectAttr "polyExtrudeFace48.out" "pCube3Shape.i";
connectAttr "groupId9.id" "pCube3Shape.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pCube3Shape.iog.og[0].gco";
connectAttr "polyTweakUV5.uvtk[0]" "pCube3Shape.uvst[0].uvtw";
connectAttr "camera1_translateX.o" "camera1.tx";
connectAttr "camera1_translateY.o" "camera1.ty";
connectAttr "camera1_translateZ.o" "camera1.tz";
connectAttr "camera1_rotateX.o" "camera1.rx";
connectAttr "camera1_rotateY.o" "camera1.ry";
connectAttr "camera1_rotateZ.o" "camera1.rz";
connectAttr "camera1_visibility.o" "camera1.v";
connectAttr "camera1_scaleX.o" "camera1.sx";
connectAttr "camera1_scaleY.o" "camera1.sy";
connectAttr "camera1_scaleZ.o" "camera1.sz";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "polyCylinder1.out" "polyTweak1.ip";
connectAttr "polyTweak1.out" "polySplit1.ip";
connectAttr "polyTweak2.out" "polyBevel1.ip";
connectAttr "pCylinderShape1.wm" "polyBevel1.mp";
connectAttr "polySplit1.out" "polyTweak2.ip";
connectAttr "polyBevel1.out" "polyExtrudeFace1.ip";
connectAttr "pCylinderShape1.wm" "polyExtrudeFace1.mp";
connectAttr "polyExtrudeFace1.out" "polyTweak3.ip";
connectAttr "polyTweak3.out" "deleteComponent1.ig";
connectAttr "deleteComponent1.og" "polySplit2.ip";
connectAttr "polySplit2.out" "polySplit3.ip";
connectAttr "polyTweak4.out" "polyExtrudeFace2.ip";
connectAttr "pCylinderShape1.wm" "polyExtrudeFace2.mp";
connectAttr "polySplit3.out" "polyTweak4.ip";
connectAttr "polyTweak5.out" "polyExtrudeFace3.ip";
connectAttr "pCylinderShape1.wm" "polyExtrudeFace3.mp";
connectAttr "polyExtrudeFace2.out" "polyTweak5.ip";
connectAttr "polyTweak6.out" "polyExtrudeFace4.ip";
connectAttr "pCylinderShape1.wm" "polyExtrudeFace4.mp";
connectAttr "polyExtrudeFace3.out" "polyTweak6.ip";
connectAttr "polyTweak7.out" "polyExtrudeFace5.ip";
connectAttr "pCylinderShape1.wm" "polyExtrudeFace5.mp";
connectAttr "polyExtrudeFace4.out" "polyTweak7.ip";
connectAttr "polyExtrudeFace5.out" "polyTweak8.ip";
connectAttr "polyTweak8.out" "deleteComponent2.ig";
connectAttr "polyTweak9.out" "polyExtrudeFace6.ip";
connectAttr "pCylinderShape1.wm" "polyExtrudeFace6.mp";
connectAttr "deleteComponent2.og" "polyTweak9.ip";
connectAttr "polyTweak10.out" "polyExtrudeFace7.ip";
connectAttr "pCylinderShape1.wm" "polyExtrudeFace7.mp";
connectAttr "polyExtrudeFace6.out" "polyTweak10.ip";
connectAttr "polyTweak11.out" "polyExtrudeFace8.ip";
connectAttr "pCylinderShape1.wm" "polyExtrudeFace8.mp";
connectAttr "polyExtrudeFace7.out" "polyTweak11.ip";
connectAttr "polyTweak12.out" "polyExtrudeFace9.ip";
connectAttr "pCylinderShape1.wm" "polyExtrudeFace9.mp";
connectAttr "polyExtrudeFace8.out" "polyTweak12.ip";
connectAttr "polyTweak13.out" "polyExtrudeFace10.ip";
connectAttr "pCylinderShape1.wm" "polyExtrudeFace10.mp";
connectAttr "polyExtrudeFace9.out" "polyTweak13.ip";
connectAttr "polyTweak14.out" "polyExtrudeFace11.ip";
connectAttr "pCylinderShape1.wm" "polyExtrudeFace11.mp";
connectAttr "polyExtrudeFace10.out" "polyTweak14.ip";
connectAttr "polyTweak15.out" "polyExtrudeFace12.ip";
connectAttr "pCylinderShape1.wm" "polyExtrudeFace12.mp";
connectAttr "polyExtrudeFace11.out" "polyTweak15.ip";
connectAttr "polyTweak16.out" "polyExtrudeFace13.ip";
connectAttr "pCylinderShape1.wm" "polyExtrudeFace13.mp";
connectAttr "polyExtrudeFace12.out" "polyTweak16.ip";
connectAttr "polyExtrudeFace13.out" "polyTweak17.ip";
connectAttr "polyTweak17.out" "polySplit4.ip";
connectAttr "polySplit4.out" "polySplit5.ip";
connectAttr "polySplit5.out" "polyTweak18.ip";
connectAttr "polyTweak18.out" "polySplit6.ip";
connectAttr "polySplit6.out" "polySplit7.ip";
connectAttr "polySplit7.out" "polySplit8.ip";
connectAttr "polySplit8.out" "polySplit9.ip";
connectAttr "polySphere1.out" "deleteComponent3.ig";
connectAttr "polyTweak19.out" "polyExtrudeFace14.ip";
connectAttr "pCylinderShape1.wm" "polyExtrudeFace14.mp";
connectAttr "polySplit9.out" "polyTweak19.ip";
connectAttr "polyTweak20.out" "polyExtrudeFace15.ip";
connectAttr "pCylinderShape1.wm" "polyExtrudeFace15.mp";
connectAttr "polyExtrudeFace14.out" "polyTweak20.ip";
connectAttr "deleteComponent3.og" "polyTweak21.ip";
connectAttr "polyTweak21.out" "deleteComponent4.ig";
connectAttr "deleteComponent4.og" "deleteComponent5.ig";
connectAttr "polyExtrudeFace15.out" "polyTweak22.ip";
connectAttr "polyTweak22.out" "deleteComponent6.ig";
connectAttr "deleteComponent5.og" "groupParts1.ig";
connectAttr "groupId1.id" "groupParts1.gi";
connectAttr "deleteComponent6.og" "groupParts2.ig";
connectAttr "groupId3.id" "groupParts2.gi";
connectAttr "polyTweak50.out" "polySmoothFace1.ip";
connectAttr "polyCube1.out" "polyTweak50.ip";
connectAttr "polyTweak51.out" "polyExtrudeFace33.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace33.mp";
connectAttr "polySmoothFace1.out" "polyTweak51.ip";
connectAttr "polyTweak52.out" "polyExtrudeFace34.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace34.mp";
connectAttr "polyExtrudeFace33.out" "polyTweak52.ip";
connectAttr "polyTweak53.out" "polyExtrudeFace35.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace35.mp";
connectAttr "polyExtrudeFace34.out" "polyTweak53.ip";
connectAttr "polyTweak54.out" "polyExtrudeFace36.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace36.mp";
connectAttr "polyExtrudeFace35.out" "polyTweak54.ip";
connectAttr "polyTweak55.out" "polyExtrudeFace37.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace37.mp";
connectAttr "polyExtrudeFace36.out" "polyTweak55.ip";
connectAttr "polyTweak56.out" "polyExtrudeFace38.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace38.mp";
connectAttr "polyExtrudeFace37.out" "polyTweak56.ip";
connectAttr "polyTweak57.out" "polyExtrudeFace39.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace39.mp";
connectAttr "polyExtrudeFace38.out" "polyTweak57.ip";
connectAttr "polyTweak58.out" "polyExtrudeFace40.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace40.mp";
connectAttr "polyExtrudeFace39.out" "polyTweak58.ip";
connectAttr "polyTweak59.out" "polyExtrudeFace41.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace41.mp";
connectAttr "polyExtrudeFace40.out" "polyTweak59.ip";
connectAttr "polyExtrudeFace41.out" "polyTweak60.ip";
connectAttr "polyTweak60.out" "polySplit16.ip";
connectAttr "polySplit16.out" "polySplit17.ip";
connectAttr "polyTweak61.out" "polyExtrudeFace42.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace42.mp";
connectAttr "polySplit17.out" "polyTweak61.ip";
connectAttr "polyTweak62.out" "polyExtrudeFace43.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace43.mp";
connectAttr "polyExtrudeFace42.out" "polyTweak62.ip";
connectAttr "polyTweak63.out" "polyExtrudeFace44.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace44.mp";
connectAttr "polyExtrudeFace43.out" "polyTweak63.ip";
connectAttr "polyTweak64.out" "polyExtrudeFace45.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace45.mp";
connectAttr "polyExtrudeFace44.out" "polyTweak64.ip";
connectAttr "polyTweak65.out" "polySplitRing9.ip";
connectAttr "pCubeShape1.wm" "polySplitRing9.mp";
connectAttr "polyExtrudeFace45.out" "polyTweak65.ip";
connectAttr "polySplitRing9.out" "polySplitRing10.ip";
connectAttr "pCubeShape1.wm" "polySplitRing10.mp";
connectAttr "polyTweak66.out" "polySplitRing11.ip";
connectAttr "pCubeShape1.wm" "polySplitRing11.mp";
connectAttr "polySplitRing10.out" "polyTweak66.ip";
connectAttr "polySplitRing11.out" "polySplitRing12.ip";
connectAttr "pCubeShape1.wm" "polySplitRing12.mp";
connectAttr "polyTweak67.out" "polyExtrudeFace46.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace46.mp";
connectAttr "polySplitRing12.out" "polyTweak67.ip";
connectAttr "polyTweak68.out" "polyExtrudeFace47.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace47.mp";
connectAttr "polyExtrudeFace46.out" "polyTweak68.ip";
connectAttr "polyCube2.out" "polySmoothFace2.ip";
connectAttr "polySmoothFace2.out" "polySmoothFace3.ip";
connectAttr "polySmoothFace3.out" "polyTweak69.ip";
connectAttr "polyTweak69.out" "deleteComponent7.ig";
connectAttr "polyTweak70.out" "polyCloseBorder1.ip";
connectAttr "deleteComponent7.og" "polyTweak70.ip";
connectAttr "polyCloseBorder1.out" "polySplit18.ip";
connectAttr "polySplit18.out" "polySplit19.ip";
connectAttr "polySplit19.out" "polyTweak71.ip";
connectAttr "polyTweak71.out" "deleteComponent8.ig";
connectAttr "polyExtrudeFace47.out" "polyTweak72.ip";
connectAttr "polyTweak72.out" "deleteComponent9.ig";
connectAttr "pCubeShape2.o" "polyUnite1.ip[0]";
connectAttr "pCubeShape1.o" "polyUnite1.ip[1]";
connectAttr "pCubeShape2.wm" "polyUnite1.im[0]";
connectAttr "pCubeShape1.wm" "polyUnite1.im[1]";
connectAttr "deleteComponent8.og" "groupParts3.ig";
connectAttr "groupId5.id" "groupParts3.gi";
connectAttr "deleteComponent9.og" "groupParts4.ig";
connectAttr "groupId7.id" "groupParts4.gi";
connectAttr "polyUnite1.out" "groupParts5.ig";
connectAttr "groupId9.id" "groupParts5.gi";
connectAttr "groupParts5.og" "polyTweakUV1.ip";
connectAttr "polyTweak73.out" "polyMergeVert1.ip";
connectAttr "pCube3Shape.wm" "polyMergeVert1.mp";
connectAttr "polyTweakUV1.out" "polyTweak73.ip";
connectAttr "polyMergeVert1.out" "polyTweakUV2.ip";
connectAttr "polyTweak74.out" "polyMergeVert2.ip";
connectAttr "pCube3Shape.wm" "polyMergeVert2.mp";
connectAttr "polyTweakUV2.out" "polyTweak74.ip";
connectAttr "polyMergeVert2.out" "polyTweakUV3.ip";
connectAttr "polyTweak75.out" "polyMergeVert3.ip";
connectAttr "pCube3Shape.wm" "polyMergeVert3.mp";
connectAttr "polyTweakUV3.out" "polyTweak75.ip";
connectAttr "polyMergeVert3.out" "polyTweakUV4.ip";
connectAttr "polyTweak76.out" "polyMergeVert4.ip";
connectAttr "pCube3Shape.wm" "polyMergeVert4.mp";
connectAttr "polyTweakUV4.out" "polyTweak76.ip";
connectAttr "polyMergeVert4.out" "polyTweakUV5.ip";
connectAttr "polyTweak77.out" "polyMergeVert5.ip";
connectAttr "pCube3Shape.wm" "polyMergeVert5.mp";
connectAttr "polyTweakUV5.out" "polyTweak77.ip";
connectAttr "polyTweak78.out" "polySplitRing13.ip";
connectAttr "pCube3Shape.wm" "polySplitRing13.mp";
connectAttr "polyMergeVert5.out" "polyTweak78.ip";
connectAttr "polyTweak79.out" "polyDelEdge1.ip";
connectAttr "polySplitRing13.out" "polyTweak79.ip";
connectAttr "polyTweak80.out" "polySoftEdge1.ip";
connectAttr "pCube3Shape.wm" "polySoftEdge1.mp";
connectAttr "polyDelEdge1.out" "polyTweak80.ip";
connectAttr "polySoftEdge1.out" "polyNormalPerVertex1.ip";
connectAttr "polyTweak81.out" "polyExtrudeFace48.ip";
connectAttr "pCube3Shape.wm" "polyExtrudeFace48.mp";
connectAttr "polyNormalPerVertex1.out" "polyTweak81.ip";
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "pSphereShape1.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pSphereShape1.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCylinderShape1.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCylinderShape1.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape2.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape2.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape1.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape1.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCube3Shape.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "groupId1.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId2.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId3.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId4.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId5.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId6.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId7.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId8.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId9.msg" ":initialShadingGroup.gn" -na;
// End of Zombe.0001.ma
