import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FileManagerService } from '../Services/fileManager.service';
import { FileUploadComponent } from './file-upload/file-upload.component';

@NgModule({
  declarations: [ FileUploadComponent, FileUploadComponent],
  imports: [FormsModule, CommonModule],
  providers: [FileManagerService],
  exports: [FileUploadComponent],
})
export class SharedModule {}
