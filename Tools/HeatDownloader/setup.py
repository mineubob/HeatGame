from setuptools import setup, find_packages
from pathlib import Path

# TODO: fix this crap later
def read_version():
    version_file = Path('heat_downloader/__init__.py').read_text()
    for line in version_file.splitlines():
        if line.startswith('__version__'):
            delim = '"' if '"' in line else "'"
            return line.split(delim)[1]
    raise RuntimeError("Unable to find version string.")


setup(
    name = 'heat-downloader',
    version = read_version(),
    description = 'A tool to download the latest Heat releases',
    author = 'Yossi99',
    packages = find_packages(),
    install_requires = Path('requirements.txt').read_text().splitlines(),
    entry_points = {
        'console_scripts': [
            'heat-downloader=heat_downloader.cli:run'
        ]
    }
)