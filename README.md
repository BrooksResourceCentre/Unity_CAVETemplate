# Overview

This repository is a basic Unity template for a three wall and one floor CAVE system with appropriate scene projection.
Expanding on the work by [Apt AS](https://github.com/aptas) within [Off-axis projection in Unity](https://github.com/aptas/off-axis-projection-unity).

Within this project are configurations for the Brooks CAVE, a 5m by 5m floorspace, with walls 2.8125m.





## UNFINISHED DRAFT: How it works


### Intro
The technique implemented from the pervious project is 'off-axis projection'. With this method a camera's near plane and camera point are disconnected, for this CAVE project, each rendered real surface has a camera with a corrisponding near render plane, that near plane has a fixed size and position to replicate the physical real-world CAVE space.

Using this technique, where near planes are used to replicate the CAVE's physical space, only content outside of the CAVE will be rendered but should mean that no warping effects occur.
To reinstate, with the Brooks CAVE this means that **anything withing the render space (5m by 5m floorspace, with walls 2.8125) will not be rendered.**



## UNFINISHED DRAFT: How to use

1. Include the appropriate prefab for your desired setup (e.g. a selection of walla and the floor) into your desired scene.



## UNFINISHED DRAFT: Development Roadmap

- Performance stress test. Is this implementaion suitable?
