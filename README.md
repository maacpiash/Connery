<h1 align="center">Connery</h1>

<h3 align="center">
    Fruit Image Classifier Using Convolutional Neural Networks
</h3>

<p align="center">
    <a href="https://github.com/maacpiash/Connery/graphs/commit-activity">
        <img src="https://img.shields.io/badge/Status-WIP-yellow?style=flat-square" alt="Status">
    </a>
    <a href="https://www.igi-global.com/gateway/article/236206">
        <img src="https://img.shields.io/badge/DOI-10.4018%2FIJSI.2019100103-green?style=flat-square" alt="DOI">
    </a>
</p>


## Technical details

The project is developed using [ML.NET](https://dotnet.microsoft.com/apps/machinelearning-ai/ml-dotnet). The web API is developed using [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet). Both these frameworks are free, cross-platform, and open-source.

## Necessary assets

The [image dataset with images in labeled folders](https://1drv.ms/u/s!Al5VLgIxS8bWgeIgldY0x-GfxXWe6A?e=t3dUm2) should be downloaded and unzipped inside a directory named `assets` inside the root directory.

## File organization

Besides the `assets` directory, there should be an empty directory in the root folder named `workspace`, where the trained model will be.

```shell
Connery/
├───assets/
│   ├───img_data/
│   │   ├───fresh_apple/
│   │   ├───fresh_banana/
│   │   ├───fresh_mango/
│   │   ├───fresh_orange/
│   │   ├───rotten_apple/
│   │   ├───rotten_banana/
│   │   ├───rotten_mango/
│   │   └───rotten_orange/
│   └───img_test/
└───workspace/
```

## Acknowledgement

I followed the instruction described in official ML.NET documentation [here](https://docs.microsoft.com/en-us/dotnet/machine-learning/tutorials/image-classification-api-transfer-learning).

This project was originally implemented as a course project during my CSE499 course at North South University over two semesters in 2018. I would like to thank my course supervisor, [Dr. Rashedur M. Rahman](http://ece.northsouth.edu/people/rashedur-rahman/).
