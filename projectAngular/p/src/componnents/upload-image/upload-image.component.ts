import { Component, ElementRef, ViewChild, AfterViewInit } from '@angular/core';
import * as tf from '@tensorflow/tfjs';
import * as posedetection from '@tensorflow-models/pose-detection';

@Component({
  selector: 'app-upload-image',
  templateUrl: './upload-image.component.html',
  styleUrls: ['./upload-image.component.css']
})
export class UploadImageComponent implements AfterViewInit {
  babyImageSrc: string | null = null;
  selectedCloth: string = 'shirt.jpg';

  clothes = [
    { name: 'חולצה כחולה', src: 'shirt.jpg' },
    { name: 'סוודר אדום', src: 'shirt.jpg' },
    { name: 'שמלה ורודה', src: 'shirt.jpg' }
  ]

  @ViewChild('babyImg', { static: false }) babyImg!: ElementRef;
  @ViewChild('clothImg', { static: false }) clothImg!: ElementRef;

  ngAfterViewInit() {
    // לוודא שהאלמנטים קיימים
    if (this.babyImg && this.clothImg) {
      // כל הקוד שקשור לאלמנטים כאן
    }
  }

  onFileSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e) => {
        const result = e.target?.result;
        if (result !== undefined) {
          this.babyImageSrc = result as string;
          setTimeout(() => this.updateClothingPosition(), 500);
        }
      };
      reader.readAsDataURL(file);
    }
  }

  async detectPose(imageElement: HTMLImageElement) {
    const detector = await posedetection.createDetector(posedetection.SupportedModels.BlazePose, {
      runtime: 'tfjs'
    });

    const poses = await detector.estimatePoses(imageElement);
    return poses;
  }

  async updateClothingPosition() {
    if (this.babyImg && this.clothImg) {
      const poses = await this.detectPose(this.babyImg.nativeElement);
      if (poses.length > 0) {
        const keypoints = poses[0].keypoints;
        const leftShoulder = keypoints.find(k => k.name === 'left_shoulder');
        const rightShoulder = keypoints.find(k => k.name === 'right_shoulder');
        const leftHip = keypoints.find(k => k.name === 'left_hip');

        if (leftShoulder && rightShoulder && leftHip) {
          const width = Math.abs(rightShoulder.x - leftShoulder.x) * 1.5;
          const height = Math.abs(leftHip.y - leftShoulder.y) * 1.5;

          this.clothImg.nativeElement.style.width = `${width}px`;
          this.clothImg.nativeElement.style.height = `${height}px`;
          this.clothImg.nativeElement.style.left = `${leftShoulder.x - width / 4}px`;
          this.clothImg.nativeElement.style.top = `${leftShoulder.y}px`;

          const angle = Math.atan2(rightShoulder.y - leftShoulder.y, rightShoulder.x - leftShoulder.x);
          this.clothImg.nativeElement.style.transform = `rotate(${angle}rad)`;
        }
      }
    }
  }
  onClothSelected(event: Event) {
    const target = event.target as HTMLSelectElement;
    this.selectedCloth = target.value;
  }
  
}
