using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.CB
{
    /// <summary>
    /// �û�����,
    /// </summary>
    [Table("UserGroupRegister")]
    public class UserGroupRegister
    {

        /// <summary>
        /// ������ 8λ��ţ���0~9��������ɣ�
        /// </summary>
        [Key]
        public String UGR_ID { get; set; }

        /// <summary>
        /// �����
        /// </summary>
        public String BookNo { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// ��������� 0 ˫�³��� 1 ���³��� 2 ���³���
        /// </summary>
        public Int16? TypeID { get; set; }

        /// <summary>
        /// ����ԱID
        /// </summary>
        public String EmployeeID { get; set; }

        /// <summary>
        /// ��������ID
        /// </summary>
        public Int32? DepartmentID { get; set; }

        /// <summary>
        /// �������������
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// �����״̬��0 ���� 1 ͣ�� 2 �ƻ�
        /// </summary>
        public Int16? Status { get; set; }

        /// <summary>
        /// ˵��
        /// </summary>
        public String Context { get; set; }

        /// <summary>
        /// ��һ��ִ��ʱ��
        /// </summary>
        public DateTime? LastExecuteDate { get; set; }

        /// <summary>
        /// ��һ��ִ���·�
        /// </summary>
        public DateTime? NextExecuteMonth { get; set; }

        /// <summary>
        /// ִ������
        /// </summary>
        public String ExecuteDay { get; set; }

        /// <summary>
        /// ������ͣ�0 ���� 1 ����ҵ 
        /// </summary>
        public String BookType { get; set; }

    }
}