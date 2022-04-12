# Minion Processes
![build workflow](https://github.com/MapManagement/MinionProcesses/actions/workflows/build-action.yml/badge.svg)

## [Minion](https://github.com/MapManagement/Minion) and MinionProcesses
I decided to split Minion into two  separate repositories. This repository
only contains the pure logic of interacting with KVM/QEMU guests. The
other repository includes a GUI application and a CLI implementation of
all processes that have been developed within this project.

## [QEMU](https://www.qemu.org/)
Many QEMU commands will be represented as simple C# methods that use common C# classes
and interfaces for most QEMU processes. I try to implement as many components that QEMU
takes care of as possible. If you're missing something simply just open an issue or
even a pull request.

## [libvirt](https://libvirt.org/)
Similar to QEMU commands I also want to offer a wide range of libvirt commands and
processes. Each C# implementation also uses my pre-defined classes and interfaces.
